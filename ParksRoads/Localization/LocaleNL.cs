// <copyright file="LocaleNL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleNL.cs
// Dutch (nl-NL) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleNL : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleNL(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ActionsTab), "Acties" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "Over" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "Parkonderhoud" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "Wegreparatie" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "Rijstrookslijtage" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "Ondersteuningslinks" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "Statusrapport / debug" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "Grootte depotvloot" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "Schaalt het **maximale aantal voertuigen** van het parkonderhoudsdepot.\n" +
                    "**100%** = standaard." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "Werkcapaciteit" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Schaalt de **werkcapaciteit** van parkonderhoud.\n" +
                    "Dit is al het werk dat een onderhoudsvoertuig kan doen voordat het terugkeert naar het gebouw.\n" +
                    "**100%** = standaard." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "Werksnelheid" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "Schaalt hoe snel parkonderhoudsvoertuigen werken.\n" +
                    "**100%** = standaard." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Parkonderhoud resetten" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Zet alle parkonderhoudswaarden terug naar **100%**." },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "Grootte depotvloot" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "Schaalt het **maximale aantal voertuigen** van het wegonderhoudsdepot.\n" +
                    "Hogere waarden laten meer wegonderhoudsvoertuigen toe.\n" +
                    "**100%** = standaard." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "Werkcapaciteit" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Schaalt de **werkcapaciteit** van wegonderhoud.\n" +
                    "Hogere waarden laten voertuigen meer reparatiewerk doen voordat ze teruggaan naar het depot.\n" +
                    "**100%** = standaard." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "Reparatiesnelheid" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "Schaalt hoe snel wegonderhoudsvoertuigen wegen repareren.\n" +
                    "**100%** = standaard." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Wegreparatie resetten" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Zet depotvloot, werkcapaciteit en reparatiesnelheid terug naar **100%**." },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "Rijstrookslijtage / wegschade" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "Bepaalt hoe snel wegen slijten door **tijd en verkeer**.\n" +
                    "**5%** = veel langzamere slijtage.\n" +
                    "**100%** = standaard.\n" +
                    "**500%** = snellere slijtage.\n" +
                    "Wijzigt de rijstrookdata voor slijtage / wegschade." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Rijstrookslijtage resetten" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Zet rijstrookslijtage terug naar **100%** zonder de wegreparatie-instellingen te wijzigen." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "Weergavenaam van deze mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Versie" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Huidige modversie en buildtype." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mochi's Paradox-mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Open River-mochi's Paradox-modspagina." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "Open de community-Discord in een browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "Scanrapport" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "Maakt een eenmalig rapport voor parken, wegreparatie en rijstrookslijtage.\n" +
                    "Niet nodig voor normaal spelen.\n" +
                    "Bestandslocatie: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "Klik één keer, wacht tot de status Klaar toont en gebruik daarna <Rapportmap openen>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "Status scanrapport" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "Toont de status: Inactief / In wachtrij / Bezig / Klaar / Mislukt.\n" +
                    "Klaar toont de duur en eindtijd." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "Uitgebreide debuglogs" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "Schrijft extra informatie naar <ParksRoads.log> voor probleemoplossing.\n" +
                    "Uitschakelen voor normaal spelen." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "Log openen" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "Open <Logs/ParksRoads.log>, of de map Logs als het bestand nog niet bestaat.\n" +
                    "Je kunt Notepad++ gebruiken om logbestanden te bekijken." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "Rapportmap openen" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "Open de rapportmap.\n" +
                    "Open daarna <ScanReport-ParksRoads.txt> met je teksteditor." },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "Inactief" },
                { "PRL_SCAN_QUEUED_FMT", "In wachtrij ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "Bezig ({0})" },
                { "PRL_SCAN_DONE_FMT", "Klaar ({0} | {1})" },
                { "PRL_SCAN_FAILED", "Mislukt" },
                { "PRL_SCAN_FAIL_NO_CITY", "Laad eerst een stad" },
                { "PRL_SCAN_UNKNOWN_TIME", "onbekende tijd" },
            };
        }

        public void Unload()
        {
        }
    }
}
