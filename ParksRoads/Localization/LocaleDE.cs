// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleDE.cs
// German (de-DE) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleDE : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleDE(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "Über" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "Parkwartung" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "Straßenreparatur" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "Fahrbahnverschleiß" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "Support-Links" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "Statusbericht / Debug" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "Depotflotte" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "Skaliert die **maximale Fahrzeugzahl** des Parkwartungsdepots.\n" +
                    "**100%** = Vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "Arbeitskapazität" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Skaliert die **Arbeitskapazität** der Parkwartung.\n" +
                    "Das ist die gesamte Arbeit, die ein Wartungsfahrzeug erledigen kann, bevor es zum Gebäude zurückkehrt.\n" +
                    "**100%** = Vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "Arbeitsgeschwindigkeit" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "Skaliert, wie schnell Parkwartungsfahrzeuge arbeiten.\n" +
                    "**100%** = Vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Parkwartung zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Setzt alle Parkwartungswerte auf **100%** zurück." },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "Depotflotte" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "Skaliert die **maximale Fahrzeugzahl** des Straßenwartungsdepots.\n" +
                    "Höhere Werte erlauben mehr Straßenwartungsfahrzeuge.\n" +
                    "**100%** = Vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "Arbeitskapazität" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Skaliert die **Arbeitskapazität** der Straßenwartung.\n" +
                    "Höhere Werte lassen Fahrzeuge mehr Reparaturarbeit erledigen, bevor sie zum Depot zurückkehren.\n" +
                    "**100%** = Vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "Reparaturgeschwindigkeit" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "Skaliert, wie schnell Straßenwartungsfahrzeuge Straßen reparieren.\n" +
                    "**100%** = Vanilla." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Straßenreparatur zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Setzt Depotflotte, Arbeitskapazität und Reparaturgeschwindigkeit auf **100%** zurück." },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "Fahrbahnverschleiß / Straßenschäden" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "Steuert, wie schnell Straßen durch **Zeit und Verkehr** verschleißen.\n" +
                    "**5%** = deutlich langsamerer Straßenverschleiß.\n" +
                    "**100%** = Vanilla.\n" +
                    "**500%** = schnellerer Straßenverschleiß.\n" +
                    "Ändert die Fahrbahn-Verschleißdaten für Straßenverschleiß / Schäden." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Fahrbahnverschleiß zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Setzt den Fahrbahnverschleiß auf **100%** zurück, ohne die Straßenreparatur-Einstellungen zu ändern." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "Anzeigename dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Aktuelle Mod-Version und Build-Typ." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mochis Paradox-Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Öffnet River-mochis Paradox-Mods-Seite." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "Öffnet den Community-Discord im Browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "Scanbericht" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "Erstellt einen einmaligen Bericht für Parks, Straßenreparatur und Fahrbahnverschleiß.\n" +
                    "Für normales Spielen nicht nötig.\n" +
                    "Dateipfad: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "Einmal klicken, auf den Status Fertig warten und dann <Berichtsordner öffnen> verwenden." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "Scanbericht-Status" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "Zeigt den Scanstatus: Bereit / In Warteschlange / Läuft / Fertig / Fehlgeschlagen.\n" +
                    "Bei Fertig werden Dauer und Abschlusszeit angezeigt." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "Ausführliche Debug-Logs" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "Schreibt zusätzliche Details zur Fehleranalyse in <ParksRoads.log>.\n" +
                    "Für normales Spielen deaktivieren." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "Log öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "Öffnet <Logs/ParksRoads.log> oder den Logs-Ordner, falls die Datei noch nicht existiert.\n" +
                    "Logdateien können mit Notepad++ geöffnet werden." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "Berichtsordner öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "Öffnet den Berichtsordner.\n" +
                    "Danach <ScanReport-ParksRoads.txt> mit einem Texteditor öffnen." },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "Bereit" },
                { "PRL_SCAN_QUEUED_FMT", "In Warteschlange ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "Läuft ({0})" },
                { "PRL_SCAN_DONE_FMT", "Fertig ({0} | {1})" },
                { "PRL_SCAN_FAILED", "Fehlgeschlagen" },
                { "PRL_SCAN_FAIL_NO_CITY", "Zuerst eine Stadt laden" },
                { "PRL_SCAN_UNKNOWN_TIME", "unbekannte Zeit" },
            };
        }

        public void Unload()
        {
        }
    }
}
