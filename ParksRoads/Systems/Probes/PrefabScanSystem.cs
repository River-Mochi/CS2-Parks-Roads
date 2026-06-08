// File: Systems/Probes/PrefabScanSystem.cs
// Purpose: One-shot prefab scan triggered by Options UI button.
// Output: Writes report to {UserData}/ModsData/ParksRoads/ScanReport-ParksRoads.txt
// Notes:
// - Runs only when requested.
// - First split-mod pass: Parks, road maintenance, lane wear only.

namespace ParksRoads
{
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Prefabs;
    using Game.SceneFlow;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using Unity.Entities;

    public sealed partial class PrefabScanSystem : GameSystemBase
    {
        private PrefabSystem m_PrefabSystem = null!;

        private const int kMaxLines = 10000;
        private const int kMaxLaneDetails = 250;
        private const int kMaxMaintenanceVehicleDetails = 500;
        private const int kMaxMaintenanceDepotDetails = 500;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            RequireForUpdate(SystemAPI.QueryBuilder().WithAll<PrefabData>().Build());

            Enabled = false;
        }

        protected override void OnUpdate()
        {
            if (PrefabScanState.CurrentPhase != PrefabScanState.Phase.Requested)
            {
                Enabled = false;
                return;
            }

            GameManager gm = GameManager.instance;
            if (gm == null || !gm.gameMode.IsGame())
            {
                PrefabScanState.MarkFailed(PrefabScanState.FailCode.NoCityLoaded, null);
                Enabled = false;
                return;
            }

            PrefabScanState.MarkRunning();

            Stopwatch sw = Stopwatch.StartNew();

            int laneTotal = 0;
            int maintenanceVehicleTotal = 0;
            int maintenanceDepotTotal = 0;

            try
            {
                StringBuilder sb = new StringBuilder(128 * 1024);
                int lines = 0;
                bool truncated = false;

                void Append(string line)
                {
                    AppendCappedLocal(sb, ref lines, ref truncated, line);
                }

                string NameOf(Entity e) => PrefabNameUtil.GetNameSafe(m_PrefabSystem, e);

                // Header
                Append($"Prefab Scan Report for: {Mod.ModName} {Mod.ModVersion}");
                Append($"Timestamp (local): {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                Append("");
                Append("Scope: Parks maintenance, road maintenance / road repair, lane wear / road damage.");
                Append("");

                // Current settings
                Append("== Current settings ==");
                if (Mod.Settings == null)
                {
                    Append("Settings unavailable.");
                }
                else
                {
                    Setting s = Mod.Settings;

                    Append($"Park depot fleet size: {s.ParkMaintenanceDepotScalar:0.#}%");
                    Append($"Park vehicle work shift capacity: {s.ParkMaintenanceVehicleCapacityScalar:0.#}%");
                    Append($"Park vehicle work rate: {s.ParkMaintenanceVehicleRateScalar:0.#}%");
                    Append("");

                    Append($"Road depot fleet size: {s.RoadMaintenanceDepotScalar:0.#}%");
                    Append($"Road vehicle work shift capacity: {s.RoadMaintenanceVehicleCapacityScalar:0.#}%");
                    Append($"Road vehicle repair rate: {s.RoadMaintenanceVehicleRateScalar:0.#}%");
                    Append($"Lane wear / road damage: {s.RoadWearScalar:0.#}%");
                }

                Append("");

                // Lane wear prefabs
                const float kUpdatesPerDay = 16f;

                Append("== Lane wear / road damage prefabs ==");
                Append("Wear sources:");
                Append("- Time wear: LaneCondition.m_Wear += (1/16) * TimeFactor per deterioration tick.");
                Append("- Traffic wear: vehicle navigation adds side effects * TrafficFactor when vehicles traverse lanes.");
                Append("");

                int laneListed = 0;
                float minTimeFactor = float.MaxValue;
                float maxTimeFactor = float.MinValue;
                float minTrafficFactor = float.MaxValue;
                float maxTrafficFactor = float.MinValue;

                foreach ((RefRO<LaneDeteriorationData> laneRef, Entity e) in SystemAPI
                             .Query<RefRO<LaneDeteriorationData>>()
                             .WithAll<PrefabData>()
                             .WithEntityAccess())
                {
                    if (truncated)
                    {
                        break;
                    }

                    laneTotal++;

                    LaneDeteriorationData cur = laneRef.ValueRO;
                    float timeFactor = cur.m_TimeFactor;
                    float trafficFactor = cur.m_TrafficFactor;

                    if (timeFactor < minTimeFactor) minTimeFactor = timeFactor;
                    if (timeFactor > maxTimeFactor) maxTimeFactor = timeFactor;
                    if (trafficFactor < minTrafficFactor) minTrafficFactor = trafficFactor;
                    if (trafficFactor > maxTrafficFactor) maxTrafficFactor = trafficFactor;

                    if (laneListed < kMaxLaneDetails)
                    {
                        float vanillaTime = float.NaN;
                        float vanillaTraffic = float.NaN;

                        if (m_PrefabSystem.TryGetPrefab(e, out PrefabBase prefabBase) &&
                            prefabBase.TryGet(out Game.Prefabs.LaneDeterioration author))
                        {
                            vanillaTime = author.m_TimeDeterioration;
                            vanillaTraffic = author.m_TrafficDeterioration;
                        }

                        float timeScalar = (!float.IsNaN(vanillaTime) && vanillaTime > 0f)
                            ? timeFactor / vanillaTime
                            : float.NaN;

                        float trafficScalar = (!float.IsNaN(vanillaTraffic) && vanillaTraffic > 0f)
                            ? trafficFactor / vanillaTraffic
                            : float.NaN;

                        float expectedTimePerTick = timeFactor / kUpdatesPerDay;

                        Append(
                            $"- {NameOf(e)} ({e.Index}:{e.Version}) " +
                            $"Vanilla(Time={FmtLocal(vanillaTime)}, Traffic={FmtLocal(vanillaTraffic)}) " +
                            $"Current(Time={timeFactor:0.###}, Traffic={trafficFactor:0.###}) " +
                            $"xTime={FmtLocal(timeScalar)} xTraffic={FmtLocal(trafficScalar)} " +
                            $"ExpDeltaTimePerTick={expectedTimePerTick:0.###}");

                        laneListed++;
                    }
                }

                if (laneTotal > laneListed)
                {
                    Append($"(Lane details capped) Printed={laneListed} of Total={laneTotal}.");
                }

                Append("");
                Append(laneTotal > 0
                    ? $"Lane wear summary: Total={laneTotal} TimeFactor(min={minTimeFactor:0.###}, max={maxTimeFactor:0.###}) TrafficFactor(min={minTrafficFactor:0.###}, max={maxTrafficFactor:0.###})"
                    : "Lane wear summary: Total=0");
                Append("");

                // Keep this live lane section if the partial report file still provides it.
                AppendLiveLaneUsage(sb, ref lines, ref truncated);
                Append("");

                // Maintenance vehicles
                Append("== Maintenance vehicle prefabs ==");
                int maintenanceVehicleListed = 0;

                foreach ((RefRO<MaintenanceVehicleData> mvRef, Entity e) in SystemAPI
                             .Query<RefRO<MaintenanceVehicleData>>()
                             .WithAll<PrefabData>()
                             .WithEntityAccess())
                {
                    if (truncated)
                    {
                        break;
                    }

                    maintenanceVehicleTotal++;

                    if (maintenanceVehicleListed >= kMaxMaintenanceVehicleDetails)
                    {
                        continue;
                    }

                    MaintenanceVehicleData mv = mvRef.ValueRO;

                    int vanillaCapacity = mv.m_MaintenanceCapacity;
                    int vanillaRate = mv.m_MaintenanceRate;

                    if (m_PrefabSystem.TryGetPrefab(e, out PrefabBase prefabBase) &&
                        prefabBase.TryGet(out Game.Prefabs.MaintenanceVehicle baseVehicle))
                    {
                        vanillaCapacity = baseVehicle.m_MaintenanceCapacity;
                        vanillaRate = baseVehicle.m_MaintenanceRate;
                    }

                    Append(
                        $"- {NameOf(e)} ({e.Index}:{e.Version}) " +
                        $"Type={mv.m_MaintenanceType} " +
                        $"VanillaCap={vanillaCapacity} CurCap={mv.m_MaintenanceCapacity} " +
                        $"VanillaRate={vanillaRate} CurRate={mv.m_MaintenanceRate}");

                    maintenanceVehicleListed++;
                }

                if (maintenanceVehicleTotal > maintenanceVehicleListed)
                {
                    Append($"(Maintenance vehicle details capped) Printed={maintenanceVehicleListed} of Total={maintenanceVehicleTotal}.");
                }

                Append($"Maintenance vehicle summary: Total={maintenanceVehicleTotal}");
                Append("");

                // Maintenance depots
                Append("== Maintenance depot prefabs ==");
                int maintenanceDepotListed = 0;

                foreach ((RefRO<MaintenanceDepotData> depotRef, Entity e) in SystemAPI
                             .Query<RefRO<MaintenanceDepotData>>()
                             .WithAll<PrefabData>()
                             .WithEntityAccess())
                {
                    if (truncated)
                    {
                        break;
                    }

                    maintenanceDepotTotal++;

                    if (maintenanceDepotListed >= kMaxMaintenanceDepotDetails)
                    {
                        continue;
                    }

                    MaintenanceDepotData depot = depotRef.ValueRO;

                    int vanillaVehicles = depot.m_VehicleCapacity;

                    if (m_PrefabSystem.TryGetPrefab(e, out PrefabBase prefabBase) &&
                        prefabBase.TryGet(out Game.Prefabs.MaintenanceDepot baseDepot))
                    {
                        vanillaVehicles = baseDepot.m_VehicleCapacity;
                    }

                    Append(
                        $"- {NameOf(e)} ({e.Index}:{e.Version}) " +
                        $"Type={depot.m_MaintenanceType} " +
                        $"VanillaVehicles={vanillaVehicles} CurVehicles={depot.m_VehicleCapacity}");

                    maintenanceDepotListed++;
                }

                if (maintenanceDepotTotal > maintenanceDepotListed)
                {
                    Append($"(Maintenance depot details capped) Printed={maintenanceDepotListed} of Total={maintenanceDepotTotal}.");
                }

                Append($"Maintenance depot summary: Total={maintenanceDepotTotal}");
                Append("");

                if (truncated)
                {
                    Append("");
                    Append($"REPORT TRUNCATED at {kMaxLines} lines.");
                }

                string reportPath = GetReportPathLocal();
                string dir = Path.GetDirectoryName(reportPath) ?? string.Empty;
                if (dir.Length > 0)
                {
                    Directory.CreateDirectory(dir);
                }

                File.WriteAllText(reportPath, sb.ToString(), Encoding.UTF8);

                sw.Stop();

                PrefabScanState.MarkDone(sw.Elapsed, reportPath);

                LogUtils.Info(Mod.s_Log, () => $"{Mod.ModTag} Prefab scan done in {sw.Elapsed.TotalSeconds:0.0}s. Report: {reportPath}");
                LogUtils.Info(
                    Mod.s_Log,
                    () =>
                        $"{Mod.ModTag} PrefabScan counts: " +
                        $"MaintVehicles={maintenanceVehicleTotal}, MaintDepots={maintenanceDepotTotal}, LaneWearPrefabs={laneTotal}");
            }
            catch (Exception ex)
            {
                sw.Stop();
                PrefabScanState.MarkFailed(PrefabScanState.FailCode.Exception, $"{ex.GetType().Name}: {ex.Message}");
                LogUtils.Warn(Mod.s_Log, () => $"{Mod.ModTag} Prefab scan failed: {ex.GetType().Name}: {ex.Message}");
            }

            Enabled = false;
        }

        private static void AppendCappedLocal(StringBuilder sb, ref int lines, ref bool truncated, string line)
        {
            if (truncated)
            {
                return;
            }

            if (lines >= kMaxLines || sb.Length >= 1024 * 1024)
            {
                truncated = true;
                return;
            }

            sb.AppendLine(line ?? string.Empty);
            lines++;
        }

        private static string FmtLocal(float value)
        {
            if (float.IsNaN(value))
            {
                return "n/a";
            }

            if (float.IsInfinity(value))
            {
                return value > 0f ? "+inf" : "-inf";
            }

            return value.ToString("0.###");
        }

private static string GetReportPathLocal()
{
    return Path.Combine(
        ShellOpen.GetModsDataFolder(),
        "ScanReport-ParksRoads.txt");
}
    }
}
