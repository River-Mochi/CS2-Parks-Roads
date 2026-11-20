// <copyright file="LaneWearSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/LaneWearSystem.cs
// Purpose: Apply RoadWearScalar (percent) to BOTH LaneDeteriorationData.m_TimeFactor and m_TrafficFactor (prefab lane deterioration settings).
// Notes:
// - Run-once system: enabled on city load or when settings Apply() enables it.
// - Reads authoring factors when available and caches them per prefab entity so changes do not stack.
// - Affects how quickly lanes accumulate deterioration from BOTH time and traffic.
// - At 0%, clears existing wear and releases obsolete road-only maintenance routes.
// - Preserve accident response and any other queued non-road work.

namespace ParksRoads
{
    using Colossal.Serialization.Entities;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Common;
    using Game.Events;
    using Game.Net;
    using Game.Pathfind;
    using Game.Prefabs;
    using Game.Simulation;
    using Game.Tools;
    using Game.SceneFlow;
    using Game.Vehicles;
    using System.Collections.Generic;
    using Unity.Entities;

    public sealed partial class LaneWearSystem : GameSystemBase
    {
        private const int kSkippedTruckLogLimit = 8;

        private struct BaseFactors
        {
            public float Time;
            public float Traffic;
        }

        // Base (vanilla/current-session-original) factors per prefab entity (LaneDeteriorationData).
        private readonly Dictionary<Entity, BaseFactors> m_Base = new Dictionary<Entity, BaseFactors>();
        private PrefabSystem m_PrefabSystem = null!;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            EntityQuery q = SystemAPI.QueryBuilder()
                .WithAll<PrefabData, LaneDeteriorationData>()
                .Build();

            RequireForUpdate(q);

            Enabled = false;
        }

        protected override void OnGamePreload(Purpose purpose, GameMode mode)
        {
            base.OnGamePreload(purpose, mode);
            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            bool isRealGame =
                mode == GameMode.Game &&
                (purpose == Purpose.NewGame || purpose == Purpose.LoadGame);

            if (!isRealGame)
                return;

            m_Base.Clear();
            Enabled = true;
        }

        protected override void OnUpdate()
        {
            GameManager gm = GameManager.instance;
            if (gm == null || !gm.gameMode.IsGame())
            {
                Enabled = false;
                return;
            }

            if (Mod.Settings == null)
            {
                Enabled = false;
                return;
            }

            float percent = Mod.Settings.RoadWearScalar; // 100 = vanilla
            if (percent < PRLSettings.RoadWearMinPercent) percent = PRLSettings.RoadWearMinPercent;
            if (percent > PRLSettings.RoadWearMaxPercent) percent = PRLSettings.RoadWearMaxPercent;

            float scalar = percent / 100f;

            int total = 0;
            int changed = 0;
            int activeTimePrefabs = 0;
            int activeTrafficPrefabs = 0;

            foreach ((RefRW<LaneDeteriorationData> laneRef, Entity e) in SystemAPI
                         .Query<RefRW<LaneDeteriorationData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                total++;

                ref LaneDeteriorationData lane = ref laneRef.ValueRW;

                if (!m_Base.TryGetValue(e, out BaseFactors baseF))
                {
                    float baseTime = lane.m_TimeFactor;
                    float baseTraffic = lane.m_TrafficFactor;

                    if (m_PrefabSystem.TryGetPrefab(e, out PrefabBase prefabBase) &&
                        prefabBase.TryGet(out LaneDeterioration author))
                    {
                        baseTime = author.m_TimeDeterioration;
                        baseTraffic = author.m_TrafficDeterioration;
                    }

                    baseF = new BaseFactors
                    {
                        Time = baseTime,
                        Traffic = baseTraffic,
                    };
                    m_Base[e] = baseF;
                }

                float desiredTime = baseF.Time * scalar;
                float desiredTraffic = baseF.Traffic * scalar;

                bool any = false;

                if (lane.m_TimeFactor != desiredTime)
                {
                    lane.m_TimeFactor = desiredTime;
                    any = true;
                }

                if (lane.m_TrafficFactor != desiredTraffic)
                {
                    lane.m_TrafficFactor = desiredTraffic;
                    any = true;
                }

                if (any) changed++;
                if (lane.m_TimeFactor != 0f) activeTimePrefabs++;
                if (lane.m_TrafficFactor != 0f) activeTrafficPrefabs++;
            }

            // Clearing existing wear is a one-time action when 0% is applied or a city loads.
            // Match the live-entity filters used by vanilla NetDeteriorationSystem.
            int lanesCleared = 0;
            int roadsCleared = 0;
            int lanesScanned = 0;
            int roadsScanned = 0;
            int trucksSeen = 0;
            int trucksReturning = 0;
            int trucksOnRoadRoutes = 0;
            int trucksWithOtherWork = 0;
            int trucksRecalled = 0;
            int skippedTruckDetailsLogged = 0;

            if (percent == 0f)
            {
                foreach (RefRW<LaneCondition> condition in SystemAPI
                             .Query<RefRW<LaneCondition>>()
                             .WithAll<UpdateFrame>()
                             .WithNone<Deleted, Temp>())
                {
                    lanesScanned++;

                    if (condition.ValueRO.m_Wear != 0f)
                    {
                        condition.ValueRW.m_Wear = 0f;
                        lanesCleared++;
                    }
                }

                foreach (RefRW<NetCondition> condition in SystemAPI
                             .Query<RefRW<NetCondition>>()
                             .WithAll<UpdateFrame>()
                             .WithNone<Deleted, Temp>())
                {
                    roadsScanned++;

                    if (condition.ValueRO.m_Wear.x != 0f ||
                        condition.ValueRO.m_Wear.y != 0f)
                    {
                        condition.ValueRW.m_Wear = 0f;
                        roadsCleared++;
                    }
                }

                // A van can retain a multi-stop repair route after its roads have been
                // fully repaired. Redirect only road vehicles whose current route is
                // for a zero-priority road, and only if no other work is queued.
                // Match vanilla MaintenanceVehicleAISystem.ReturnToDepot.
                ComponentLookup<PrefabRef> vehiclePrefabs = SystemAPI.GetComponentLookup<PrefabRef>(true);
                ComponentLookup<Owner> vehicleOwners = SystemAPI.GetComponentLookup<Owner>(true);
                ComponentLookup<MaintenanceVehicleData> vehicleData =
                    SystemAPI.GetComponentLookup<MaintenanceVehicleData>(true);
                ComponentLookup<NetCondition> roadConditions =
                    SystemAPI.GetComponentLookup<NetCondition>(true);
                ComponentLookup<MaintenanceRequest> maintenanceRequests =
                    SystemAPI.GetComponentLookup<MaintenanceRequest>(true);
                ComponentLookup<InvolvedInAccident> accidents =
                    SystemAPI.GetComponentLookup<InvolvedInAccident>(true);
                ComponentLookup<Vehicle> vehicles =
                    SystemAPI.GetComponentLookup<Vehicle>(true);

                foreach ((
                    RefRW<Game.Vehicles.MaintenanceVehicle> vehicleRef,
                    RefRW<Game.Vehicles.Car> carRef,
                    RefRW<PathOwner> pathRef,
                    RefRW<Target> targetRef,
                    DynamicBuffer<ServiceDispatch> dispatches,
                    Entity entity) in SystemAPI
                         .Query<
                             RefRW<Game.Vehicles.MaintenanceVehicle>,
                             RefRW<Game.Vehicles.Car>,
                             RefRW<PathOwner>,
                             RefRW<Target>,
                             DynamicBuffer<ServiceDispatch>>()
                         .WithAll<PrefabRef, Owner>()
                         .WithNone<Deleted, Temp>()
                         .WithEntityAccess())
                {
                    PrefabRef prefabRef = vehiclePrefabs[entity];
                    if (!vehicleData.TryGetComponent(prefabRef.m_Prefab, out MaintenanceVehicleData prefab) ||
                        (prefab.m_MaintenanceType & MaintenanceType.Road) == MaintenanceType.None)
                    {
                        continue;
                    }

                    trucksSeen++;
                    MaintenanceVehicleFlags flags = vehicleRef.ValueRO.m_State;
                    if ((flags & MaintenanceVehicleFlags.Returning) != 0)
                    {
                        trucksReturning++;
                        continue;
                    }

                    Entity currentTarget = targetRef.ValueRO.m_Target;
                    if ((flags & MaintenanceVehicleFlags.EdgeTarget) == 0 ||
                        (flags & MaintenanceVehicleFlags.TransformTarget) != 0 ||
                        !roadConditions.HasComponent(currentTarget))
                    {
                        trucksWithOtherWork++;
                        if (skippedTruckDetailsLogged < kSkippedTruckLogLimit)
                        {
                            skippedTruckDetailsLogged++;
                            int pendingCount = vehicleRef.ValueRO.m_RequestCount;
                            int dispatchCount = dispatches.Length;
                            bool isRoadTarget = roadConditions.HasComponent(currentTarget);
                            bool isAccidentTarget = accidents.HasComponent(currentTarget);
                            bool isVehicleTarget = vehicles.HasComponent(currentTarget);
                            LogUtils.Info(Mod.s_Log,
                                () => $"{Mod.ModTag} Lane wear: preserved truck {entity} Reason=OtherCurrentTarget " +
                                      $"Target={currentTarget} Flags={flags} Pending={pendingCount} " +
                                      $"Dispatches={dispatchCount} RoadTarget={isRoadTarget} " +
                                      $"AccidentTarget={isAccidentTarget} VehicleTarget={isVehicleTarget}");
                        }

                        continue;
                    }

                    trucksOnRoadRoutes++;
                    if (NetDeteriorationSystem.GetMaintenancePriority(roadConditions[currentTarget]) > 0)
                    {
                        continue;
                    }

                    bool hasOtherWork = false;
                    int queuedRoad = 0;
                    int queuedNonRoad = 0;
                    int queuedAccident = 0;
                    int queuedVehicle = 0;
                    int queuedRoadPriority = 0;
                    int missingRequests = 0;

                    foreach (ServiceDispatch dispatch in dispatches)
                    {
                        if (!maintenanceRequests.TryGetComponent(dispatch.m_Request, out MaintenanceRequest request))
                        {
                            missingRequests++;
                            continue;
                        }

                        Entity requestTarget = request.m_Target;
                        if (!roadConditions.HasComponent(requestTarget))
                        {
                            hasOtherWork = true;
                            queuedNonRoad++;
                            if (accidents.HasComponent(requestTarget)) queuedAccident++;
                            if (vehicles.HasComponent(requestTarget)) queuedVehicle++;
                            continue;
                        }

                        queuedRoad++;
                        if (NetDeteriorationSystem.GetMaintenancePriority(roadConditions[requestTarget]) > 0)
                        {
                            hasOtherWork = true;
                            queuedRoadPriority++;
                        }
                    }

                    if (hasOtherWork)
                    {
                        trucksWithOtherWork++;
                        if (skippedTruckDetailsLogged < kSkippedTruckLogLimit)
                        {
                            skippedTruckDetailsLogged++;
                            int pendingCount = vehicleRef.ValueRO.m_RequestCount;
                            int dispatchCount = dispatches.Length;
                            LogUtils.Info(Mod.s_Log,
                                () => $"{Mod.ModTag} Lane wear: preserved truck {entity} Reason=QueuedOtherWork " +
                                      $"Target={currentTarget} Flags={flags} Pending={pendingCount} " +
                                      $"Dispatches={dispatchCount} QueuedRoad={queuedRoad} QueuedNonRoad={queuedNonRoad} " +
                                      $"Accident={queuedAccident} Vehicle={queuedVehicle} RoadStillNeeded={queuedRoadPriority} " +
                                      $"MissingRequests={missingRequests}");
                        }

                        continue;
                    }

                    // Clear stale stops and use the exact vanilla return-state
                    // transition and path retargeting; do not touch accident tasks.
                    dispatches.Clear();

                    ref Game.Vehicles.MaintenanceVehicle vehicle = ref vehicleRef.ValueRW;
                    vehicle.m_RequestCount = 0;
                    vehicle.m_MaintainEstimate = 0;
                    vehicle.m_State &= ~(MaintenanceVehicleFlags.TransformTarget |
                                         MaintenanceVehicleFlags.EdgeTarget |
                                         MaintenanceVehicleFlags.TryWork |
                                         MaintenanceVehicleFlags.Working |
                                         MaintenanceVehicleFlags.ClearingDebris);
                    vehicle.m_State |= MaintenanceVehicleFlags.Returning;

                    carRef.ValueRW.m_Flags &= ~(CarFlags.Warning |
                                                CarFlags.Working |
                                                CarFlags.SignalAnimation1 |
                                                CarFlags.SignalAnimation2);

                    ref PathOwner path = ref pathRef.ValueRW;
                    ref Target target = ref targetRef.ValueRW;
                    VehicleUtils.SetTarget(ref path, ref target, vehicleOwners[entity].m_Owner);
                    trucksRecalled++;
                }
            }

            // One report per city load or settings apply; no per-frame logging.
            LogUtils.Info(
                Mod.s_Log,
                () => $"{Mod.ModTag} Lane wear: Percent={percent:0.#}% " +
                      $"Prefabs={total} Changed={changed} ActiveTime={activeTimePrefabs} ActiveTraffic={activeTrafficPrefabs}" +
                      (percent == 0f
                          ? $" ClearedLanes={lanesCleared}/{lanesScanned} ClearedRoads={roadsCleared}/{roadsScanned}" +
                            $" RoadFleet={trucksSeen} RoadRoutes={trucksOnRoadRoutes} Recalled={trucksRecalled}" +
                            $" AlreadyReturning={trucksReturning} OtherWork={trucksWithOtherWork}"
                          : " WearAccumulation=on"));

            Enabled = false;
        }
    }
}
