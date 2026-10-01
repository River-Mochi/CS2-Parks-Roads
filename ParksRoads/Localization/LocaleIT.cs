// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleIT.cs
// Italian (it-IT) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleIT : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleIT(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ActionsTab), "Azioni" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "Informazioni" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "Manutenzione parchi" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "Riparazione strade" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "Usura corsie" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "Info" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "Link di supporto" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "Rapporto stato / debug" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "Dimensione flotta deposito" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "Regola il **numero massimo di veicoli** del deposito di manutenzione parchi.\n" +
                    "**100%** = gioco base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "Capacità di lavoro" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Regola la **capacità di lavoro** della manutenzione parchi.\n" +
                    "È il lavoro totale che un veicolo può svolgere prima di tornare al proprio edificio.\n" +
                    "**100%** = gioco base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "Velocità di lavoro" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "Regola la velocità di lavoro dei veicoli di manutenzione parchi.\n" +
                    "**100%** = gioco base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Ripristina manutenzione parchi" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Riporta i valori della manutenzione parchi a **100%**." },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "Dimensione flotta deposito" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "Regola il **numero massimo di veicoli** del deposito di manutenzione stradale.\n" +
                    "Valori più alti permettono più veicoli di manutenzione.\n" +
                    "**100%** = gioco base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "Capacità di lavoro" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Regola la **capacità di lavoro** della manutenzione stradale.\n" +
                    "Valori più alti permettono più riparazioni prima di tornare al deposito.\n" +
                    "**100%** = gioco base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "Velocità di riparazione" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "Regola la velocità con cui i veicoli di manutenzione riparano le strade.\n" +
                    "**100%** = gioco base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Ripristina riparazione strade" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Riporta flotta del deposito, capacità di lavoro e velocità di riparazione a **100%**." },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "Usura corsie / danni stradali" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "Controlla quanto velocemente le strade si deteriorano per **tempo e traffico**.\n" +
                    "**5%** = usura molto più lenta.\n" +
                    "**100%** = gioco base.\n" +
                    "**500%** = usura più rapida.\n" +
                    "Modifica i dati di deterioramento delle corsie per usura / danni stradali." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Ripristina usura corsie" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Riporta l’usura delle corsie a **100%** senza cambiare le impostazioni di riparazione." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "Nome visualizzato di questa mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Versione attuale della mod e tipo di build." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mod Paradox di Mochi" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Apre la pagina delle mod Paradox di River-mochi." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "Apre il Discord della community nel browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "Rapporto scansione" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "Crea un rapporto singolo per parchi, riparazione strade e usura corsie.\n" +
                    "Non serve durante il gioco normale.\n" +
                    "Percorso: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "Fai clic una volta, attendi che lo stato mostri Completato, poi usa <Apri cartella rapporto>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "Stato rapporto scansione" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "Mostra lo stato: Inattivo / In coda / In esecuzione / Completato / Errore.\n" +
                    "Completato mostra durata e ora di completamento." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "Log di debug dettagliati" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "Scrive dettagli extra in <ParksRoads.log> per la risoluzione dei problemi.\n" +
                    "Disattiva durante il gioco normale." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "Apri log" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "Apre <Logs/ParksRoads.log>, oppure la cartella Logs se il file non esiste ancora.\n" +
                    "Puoi usare Notepad++ per leggere i file di log." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "Apri cartella rapporto" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "Apre la cartella del rapporto.\n" +
                    "Poi apri <ScanReport-ParksRoads.txt> con il tuo editor di testo." },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "Inattivo" },
                { "PRL_SCAN_QUEUED_FMT", "In coda ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "In esecuzione ({0})" },
                { "PRL_SCAN_DONE_FMT", "Completato ({0} | {1})" },
                { "PRL_SCAN_FAILED", "Errore" },
                { "PRL_SCAN_FAIL_NO_CITY", "Carica prima una città" },
                { "PRL_SCAN_UNKNOWN_TIME", "ora sconosciuta" },
            };
        }

        public void Unload()
        {
        }
    }
}
