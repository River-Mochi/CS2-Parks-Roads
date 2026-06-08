// File: Localization/LocaleEN.cs
// English (en-US) strings for Options UI.

namespace ParksRoads
{
    using Colossal;
    using System.Collections.Generic;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ParksRoadsTab), "Parks + Road Repairs" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),      "About" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.ParkMaintenanceGroup), "Park maintenance" },
                { m_Setting.GetOptionGroupLocaleID(Setting.RoadMaintenanceGroup), "Road repair / lane wear" },

                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGroup),  "Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGroup), "Support links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.DebugGroup),      "Status report / debug" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceDepotScalar)), "Depot fleet size" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ParkMaintenanceDepotScalar)),
                    "Scales park maintenance depot **maximum vehicles**.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceVehicleCapacityScalar)), "Work shift capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ParkMaintenanceVehicleCapacityScalar)),
                    "Scales park maintenance **work shift capacity**.\n" +
                    "This is the total work a maintenance vehicle can do before returning to its building.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ParkMaintenanceVehicleRateScalar)), "Vehicle work rate" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ParkMaintenanceVehicleRateScalar)),
                    "Scales park maintenance **work rate**.\n" +
                    "Rate means how much work the vehicle does per simulation tick while stopped.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetParkMaintenanceToVanillaButton)), "Reset park maintenance" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetParkMaintenanceToVanillaButton)),
                    "Reset park maintenance values back to **100%**." },

                // -------------------
                // Road repair / lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceDepotScalar)), "Depot fleet size" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RoadMaintenanceDepotScalar)),
                    "Scales road maintenance depot **maximum vehicles**.\n" +
                    "Higher values allow more road maintenance trucks.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceVehicleCapacityScalar)), "Work shift capacity" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RoadMaintenanceVehicleCapacityScalar)),
                    "Scales road maintenance **work shift capacity**.\n" +
                    "Higher values let trucks do more total repair work before returning to the depot.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadMaintenanceVehicleRateScalar)), "Repair rate" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RoadMaintenanceVehicleRateScalar)),
                    "Scales road maintenance **repair rate**.\n" +
                    "Rate means how much repair work the truck performs per simulation tick while stopped.\n" +
                    "**100%** = vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RoadWearScalar)), "Lane wear / road damage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RoadWearScalar)),
                    "Controls how quickly roads deteriorate from **time and traffic**.\n" +
                    "**10%** = much slower road wear.\n" +
                    "**100%** = vanilla.\n" +
                    "**500%** = faster road wear.\n" +
                    "This changes lane deterioration data for road wear / damage." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetRoadMaintenanceToVanillaButton)), "Reset road repair" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetRoadMaintenanceToVanillaButton)),
                    "Reset road repair, maintenance, and lane wear values back to **100%**." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModNameDisplay)), "Display name of this mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ModVersionDisplay)), "Current mod version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxMods)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxMods)), "Open the author's Paradox Mods page." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Open the community Discord in a browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RunPrefabScanButton)), "Scan report" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RunPrefabScanButton)),
                    "Creates a one-time report for Parks, Road Repair, and Lane Wear.\n" +
                    "Not needed for normal gameplay.\n" +
                    "File location: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "Click once, wait for status to show Done, then use <Open report folder>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrefabScanStatus)), "Scan report status" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PrefabScanStatus)),
                    "Shows scan state: Idle / Queued / Running / Done / Failed.\n" +
                    "Done shows duration and finish time." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.EnableDebugLogging)), "Verbose debug logs" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.EnableDebugLogging)),
                    "Writes extra details to <ParksRoads.log> for troubleshooting.\n" +
                    "Disable for normal gameplay." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLogButton)), "Open log folder" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLogButton)),
                    "Open the logs folder.\n" +
                    "Then open <ParksRoads.log> with your text editor." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenReportButton)), "Open report folder" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenReportButton)),
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
