// File: Systems/Probes/PrefabScanSystem.ReportSections.cs
// Purpose: Helper/report methods for PrefabScanSystem.
// Notes:
// - Parks + Road Repairs split-mod report sections only.
// - Uses fully-qualified collection types because Unity ECS source generation can emit code
//   into .g.cs files without carrying over normal using directives.

namespace ParksRoads
{
    using Game.Net;
    using Game.Prefabs;
    using System.Text;
    using Unity.Entities;

    public sealed partial class PrefabScanSystem
    {
        private const int kMaxChars = 1 * 1024 * 1024; // ~1MB

        private void AppendLiveLaneUsage(StringBuilder sb, ref int lines, ref bool truncated)
        {
            if (truncated)
            {
                return;
            }

            AppendSectionHeader(sb, ref lines, ref truncated, "Live lane usage");
            AppendCapped(sb, ref lines, ref truncated, "Counts live lane entities grouped by PrefabRef.m_Prefab.");
            AppendCapped(sb, ref lines, ref truncated, "This checks how many live lanes use lane prefabs that have LaneDeteriorationData.");
            AppendCapped(sb, ref lines, ref truncated, "");

            global::System.Collections.Generic.HashSet<Entity> wearPrefabs =
                new global::System.Collections.Generic.HashSet<Entity>();

            foreach ((RefRO<LaneDeteriorationData> _, Entity prefabEntity) in SystemAPI
                         .Query<RefRO<LaneDeteriorationData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                wearPrefabs.Add(prefabEntity);
            }

            global::System.Collections.Generic.Dictionary<Entity, int> counts =
                new global::System.Collections.Generic.Dictionary<Entity, int>(64);

            long liveLaneTotal = 0;

            foreach (RefRO<PrefabRef> prefabRefRO in SystemAPI
                         .Query<RefRO<PrefabRef>>()
                         .WithAll<LaneCondition>()
                         .WithNone<PrefabData>())
            {
                Entity prefab = prefabRefRO.ValueRO.m_Prefab;
                liveLaneTotal++;

                if (counts.TryGetValue(prefab, out int count))
                {
                    counts[prefab] = count + 1;
                }
                else
                {
                    counts[prefab] = 1;
                }
            }

            if (liveLaneTotal == 0 || counts.Count == 0)
            {
                AppendCapped(sb, ref lines, ref truncated, "No live lanes found.");
                AppendCapped(sb, ref lines, ref truncated, "");
                return;
            }

            long covered = 0;
            foreach (global::System.Collections.Generic.KeyValuePair<Entity, int> kvp in counts)
            {
                if (wearPrefabs.Contains(kvp.Key))
                {
                    covered += kvp.Value;
                }
            }

            float percent = (float)covered * 100f / liveLaneTotal;

            AppendCapped(sb, ref lines, ref truncated, $"Live lanes summary: LiveLanes={liveLaneTotal:n0} UniqueLanePrefabs={counts.Count:n0}");
            AppendCapped(sb, ref lines, ref truncated, $"LaneDeteriorationData coverage: {covered:n0}/{liveLaneTotal:n0} ({percent:0.0}%)");
            AppendCapped(sb, ref lines, ref truncated, "");

            const int kTop = 30;

            global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<Entity, int>> top =
                new global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<Entity, int>>(counts);

            top.Sort((a, b) => b.Value.CompareTo(a.Value));

            int printed = 0;
            for (int i = 0; i < top.Count && printed < kTop; i++)
            {
                global::System.Collections.Generic.KeyValuePair<Entity, int> kvp = top[i];
                string name = PrefabNameUtil.GetNameSafe(m_PrefabSystem, kvp.Key);
                bool hasWearData = wearPrefabs.Contains(kvp.Key);

                AppendCapped(
                    sb,
                    ref lines,
                    ref truncated,
                    $"- {name} ({kvp.Key.Index}:{kvp.Key.Version}) UsedByLanes={kvp.Value:n0} HasLaneDeteriorationData={hasWearData}");

                printed++;
            }

            if (top.Count > printed)
            {
                AppendCapped(sb, ref lines, ref truncated, $"(Live lane prefab list capped) Printed={printed} of {top.Count}.");
            }

            AppendCapped(sb, ref lines, ref truncated, "");
        }

        private static void AppendSectionHeader(StringBuilder sb, ref int lines, ref bool truncated, string title)
        {
            AppendCapped(sb, ref lines, ref truncated, "================================");
            AppendCapped(sb, ref lines, ref truncated, title);
            AppendCapped(sb, ref lines, ref truncated, "================================");
        }

        private static void AppendCapped(StringBuilder sb, ref int lines, ref bool truncated, string line)
        {
            if (truncated)
            {
                return;
            }

            if (lines >= kMaxLines || sb.Length >= kMaxChars)
            {
                truncated = true;
                sb.AppendLine("!! TRUNCATED: Output hit cap.");
                lines++;
                return;
            }

            sb.AppendLine(line ?? string.Empty);
            lines++;
        }
    }
}
