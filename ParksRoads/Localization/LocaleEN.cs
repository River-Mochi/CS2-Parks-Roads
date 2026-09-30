// <copyright file="LocaleEN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleEN.cs
// English (en-US) strings for Options UI.

namespace ParksRoads
{
    using Colossal;
    using System.Collections.Generic;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleEN(PRLSettings setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            string title = Mod.ShortName;

            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {
                // --------------------------
                // Mod title / tabs / groups
                // --------------------------

                { m_Setting.GetSettingsLocaleID(), title },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ParksRoadsTab), "Parks, Roads & Lane Wear" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab),      "About" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "Park maintenance" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "Road repair / lane wear" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "Support links" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup),      "Status report / debug" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "Depot fleet size" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "Scales park maintenance depot **maximum vehicles**.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "Work shift capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Scales park maintenance **work shift capacity**.\n" +
                    "This is the total work a maintenance vehicle can do before returning to its building.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "Vehicle work rate" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "Scales park maintenance **work rate**.\n" +
                    "Rate means how much work the vehicle does per simulation tick while stopped.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Reset park maintenance" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)),
                    "Reset park maintenance values back to **100%**." },

                // -------------------
                // Road repair / lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "Depot fleet size" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "Scales road maintenance depot **maximum vehicles**.\n" +
                    "Higher values allow more road maintenance trucks.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "Work shift capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Scales road maintenance **work shift capacity**.\n" +
                    "Higher values let trucks do more total repair work before returning to the depot.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "Repair rate" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "Scales road maintenance **repair rate**.\n" +
                    "Rate means how much repair work the truck performs per simulation tick while stopped.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "Lane wear / road damage" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "Controls how quickly roads deteriorate from **time and traffic**.\n" +
                    "**10%** = much slower road wear.\n" +
                    "**100%** = vanilla.\n" +
                    "**500%** = faster road wear.\n" +
                    "This changes lane deterioration data for road wear / damage." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Reset road repair" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)),
                    "Reset road repair, maintenance, and lane wear values back to **100%**." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "Display name of this mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Current mod version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Open the author's Paradox Mods page." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "Open the community Discord in a browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "Scan report" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "Creates a one-time report for Parks, Road Repair, and Lane Wear.\n" +
                    "Not needed for normal gameplay.\n" +
                    "File location: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "Click once, wait for status to show Done, then use <Open report folder>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "Scan report status" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "Shows scan state: Idle / Queued / Running / Done / Failed.\n" +
                    "Done shows duration and finish time." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "Verbose debug logs" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "Writes extra details to <ParksRoads.log> for troubleshooting.\n" +
                    "Disable for normal gameplay." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "Open log folder" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "Open the logs folder.\n" +
                    "Then open <ParksRoads.log> with your text editor." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "Open report folder" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "Open the report folder.\n" +
                    "Then open <ScanReport-ParksRoads.txt> with your text editor." },

                // ---- Scan Report Status Text ----
                // Keep existing keys for now because PrefabScanStatusText may still call these exact IDs.
                { "PWP_SCAN_IDLE", "Idle" },
                { "PWP_SCAN_QUEUED_FMT", "Queued ({0})" },
                { "PWP_SCAN_RUNNING_FMT", "Running ({0})" },
                { "PWP_SCAN_DONE_FMT", "Done ({0} | {1})" },
                { "PWP_SCAN_FAILED", "Failed" },
                { "PWP_SCAN_FAIL_NO_CITY", "Load city first" },
                { "PWP_SCAN_UNKNOWN_TIME", "unknown time" },
            };
        }

        public void Unload()
        {
        }
    }
}
