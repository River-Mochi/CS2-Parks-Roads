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

namespace ParksRoads
{
    using Colossal.Serialization.Entities;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Prefabs;
    using Game.SceneFlow;
    using System.Collections.Generic;
    using Unity.Entities;

    public sealed partial class LaneWearSystem : GameSystemBase
    {
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

#if DEBUG
bool verbose = Mod.Settings.EnableDebugLogging;
#else
            bool verbose = false;
#endif

            float percent = Mod.Settings.RoadWearScalar; // 100 = vanilla
            if (percent < PRLSettings.RoadWearMinPercent) percent = PRLSettings.RoadWearMinPercent;
            if (percent > PRLSettings.RoadWearMaxPercent) percent = PRLSettings.RoadWearMaxPercent;

            float scalar = percent / 100f;

            int total = 0;
            int changed = 0;

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
            }

            if (verbose)
            {
                LogUtils.Info(
                    Mod.s_Log,
                    () => $"{Mod.ModTag} Lane wear: RoadWearScalar={percent:0.#}% Scalar={scalar:0.###} " +
                          $"Prefabs={total} Changed={changed} (scaled TimeFactor + TrafficFactor)");
            }

            Enabled = false;
        }
    }
}
