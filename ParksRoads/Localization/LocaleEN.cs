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
    using System.Collections.Generic;
    using Colossal;

    public class LocaleEN : IDictionarySource
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
            return new Dictionary<string, string>
            {
                // --------------------------
                // Mod title / tabs / groups
                // --------------------------

                { m_Setting.GetSettingsLocaleID(), Mod.ShortName },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab),      "About" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "Park maintenance" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "Road repair" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "Lane wear" },

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
                    "This is the total work a maintenance truck can do before returning to its building.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "Vehicle work rate" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "Scales how quickly park maintenance trucks do work.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Reset park maintenance" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)),
                    "Reset park maintenance values back to **100%**." },

                // -------------------
                // Road repair
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
                    "Scales how quickly road maintenance trucks repair roads.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Reset road repair" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)),
                    "Reset road depot fleet size, work shift capacity, and repair rate to **100%**." },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "Lane wear / road damage" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "Controls how quickly roads deteriorate from **time and traffic**.\n" +
                    "**5%** = much slower road wear.\n" +
                    "**100%** = vanilla.\n" +
                    "**500%** = faster road wear.\n" +
                    "This changes lane deterioration data for road wear / damage." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Reset lane wear" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)),
                    "Reset lane wear to **100%** without changing road repair settings." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "Display name of this mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Current mod version and build type." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mochi's Paradox mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Open River-mochi's Paradox mods page." },

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

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "Open log" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "Open <Logs/ParksRoads.log>, or the Logs folder if the file does not exist yet.\n" +
                    "Notepad++ can be used to view log files."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "Open report folder" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "Open the report folder.\n" +
                    "Then open <ScanReport-ParksRoads.txt> with your text editor." },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "Idle" },
                { "PRL_SCAN_QUEUED_FMT", "Queued ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "Running ({0})" },
                { "PRL_SCAN_DONE_FMT", "Done ({0} | {1})" },
                { "PRL_SCAN_FAILED", "Failed" },
                { "PRL_SCAN_FAIL_NO_CITY", "Load city first" },
                { "PRL_SCAN_UNKNOWN_TIME", "unknown time" },
            };
        }

        public void Unload()
        {
        }
    }
}
