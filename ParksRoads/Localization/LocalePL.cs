// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePL.cs
// Polish (pl-PL) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocalePL : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocalePL(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ActionsTab), "Akcje" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "O modzie" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "Utrzymanie parków" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "Naprawa dróg" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "Zużycie pasów" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "Informacje" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "Linki pomocy" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "Raport stanu / debug" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "Rozmiar floty zajezdni" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "Skaluje **maksymalną liczbę pojazdów** zajezdni utrzymania parków.\n" +
                    "**100%** = ustawienie gry." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "Pojemność robocza" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Skaluje **pojemność roboczą** utrzymania parków.\n" +
                    "To łączna ilość pracy, jaką pojazd może wykonać przed powrotem do budynku.\n" +
                    "**100%** = ustawienie gry." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "Tempo pracy" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "Skaluje szybkość pracy pojazdów utrzymania parków.\n" +
                    "**100%** = ustawienie gry." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Resetuj utrzymanie parków" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Przywraca wartości utrzymania parków do **100%**." },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "Rozmiar floty zajezdni" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "Skaluje **maksymalną liczbę pojazdów** zajezdni utrzymania dróg.\n" +
                    "Wyższe wartości pozwalają używać większej liczby pojazdów.\n" +
                    "**100%** = ustawienie gry." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "Pojemność robocza" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Skaluje **pojemność roboczą** utrzymania dróg.\n" +
                    "Wyższe wartości pozwalają wykonać więcej napraw przed powrotem do zajezdni.\n" +
                    "**100%** = ustawienie gry." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "Tempo naprawy" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "Skaluje szybkość naprawiania dróg przez pojazdy utrzymania.\n" +
                    "**100%** = ustawienie gry." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Resetuj naprawę dróg" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Przywraca rozmiar floty, pojemność roboczą i tempo naprawy do **100%**." },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "Zużycie pasów / uszkodzenia dróg" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "Kontroluje tempo niszczenia dróg przez **czas i ruch uliczny**.\n" +
                    "**5%** = znacznie wolniejsze zużycie.\n" +
                    "**100%** = ustawienie gry.\n" +
                    "**500%** = szybsze zużycie.\n" +
                    "Zmienia dane degradacji pasów używane dla zużycia / uszkodzeń dróg." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Resetuj zużycie pasów" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Przywraca zużycie pasów do **100%** bez zmiany ustawień naprawy dróg." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "Nazwa wyświetlana tego moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Aktualna wersja moda i typ kompilacji." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mody Mochi w Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Otwiera stronę modów River-mochi w Paradox." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "Otwiera Discord społeczności w przeglądarce." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "Raport skanowania" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "Tworzy jednorazowy raport dla parków, naprawy dróg i zużycia pasów.\n" +
                    "Nie jest potrzebny do normalnej gry.\n" +
                    "Lokalizacja: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "Kliknij raz, poczekaj na status Gotowe, a potem użyj <Otwórz folder raportu>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "Stan raportu" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "Pokazuje stan: Bezczynny / W kolejce / W toku / Gotowe / Błąd.\n" +
                    "Gotowe pokazuje czas trwania i godzinę zakończenia." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "Szczegółowe logi debug" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "Zapisuje dodatkowe informacje do <ParksRoads.log> na potrzeby diagnostyki.\n" +
                    "Wyłącz podczas normalnej gry." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "Otwórz log" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "Otwiera <Logs/ParksRoads.log> albo folder Logs, jeśli plik jeszcze nie istnieje.\n" +
                    "Pliki logów można przeglądać w Notepad++." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "Otwórz folder raportu" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "Otwiera folder raportu.\n" +
                    "Następnie otwórz <ScanReport-ParksRoads.txt> w edytorze tekstu." },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "Bezczynny" },
                { "PRL_SCAN_QUEUED_FMT", "W kolejce ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "W toku ({0})" },
                { "PRL_SCAN_DONE_FMT", "Gotowe ({0} | {1})" },
                { "PRL_SCAN_FAILED", "Błąd" },
                { "PRL_SCAN_FAIL_NO_CITY", "Najpierw wczytaj miasto" },
                { "PRL_SCAN_UNKNOWN_TIME", "nieznany czas" },
            };
        }

        public void Unload()
        {
        }
    }
}
