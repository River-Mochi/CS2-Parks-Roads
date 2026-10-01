// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleFR.cs
// French (fr-FR) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleFR : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleFR(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "À propos" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "Entretien des parcs" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "Réparation des routes" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "Usure des voies" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "Infos" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "Liens d’aide" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "Rapport d’état / debug" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "Taille de la flotte du dépôt" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "Ajuste le **nombre maximal de véhicules** du dépôt d’entretien des parcs.\n" +
                    "**100%** = jeu de base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "Capacité de travail" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Ajuste la **capacité de travail** de l’entretien des parcs.\n" +
                    "C’est le travail total qu’un véhicule peut effectuer avant de retourner à son bâtiment.\n" +
                    "**100%** = jeu de base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "Vitesse de travail" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "Ajuste la vitesse de travail des véhicules d’entretien des parcs.\n" +
                    "**100%** = jeu de base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Réinitialiser l’entretien des parcs" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Remet les valeurs d’entretien des parcs à **100%**." },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "Taille de la flotte du dépôt" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "Ajuste le **nombre maximal de véhicules** du dépôt d’entretien routier.\n" +
                    "Une valeur plus élevée permet plus de véhicules d’entretien.\n" +
                    "**100%** = jeu de base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "Capacité de travail" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Ajuste la **capacité de travail** de l’entretien routier.\n" +
                    "Une valeur plus élevée permet plus de réparations avant le retour au dépôt.\n" +
                    "**100%** = jeu de base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "Vitesse de réparation" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "Ajuste la vitesse à laquelle les véhicules d’entretien réparent les routes.\n" +
                    "**100%** = jeu de base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Réinitialiser la réparation des routes" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Remet la flotte du dépôt, la capacité de travail et la vitesse de réparation à **100%**." },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "Usure des voies / dégâts routiers" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "Contrôle la vitesse de dégradation des routes due au **temps et au trafic**.\n" +
                    "**5%** = usure beaucoup plus lente.\n" +
                    "**100%** = jeu de base.\n" +
                    "**500%** = usure plus rapide.\n" +
                    "Modifie les données de détérioration des voies pour l’usure / les dégâts routiers." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Réinitialiser l’usure des voies" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Remet l’usure des voies à **100%** sans modifier les réglages de réparation." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "Nom affiché de ce mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Version actuelle du mod et type de build." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mods Paradox de Mochi" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Ouvre la page des mods Paradox de River-mochi." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "Ouvre le Discord de la communauté dans le navigateur." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "Rapport d’analyse" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "Crée un rapport ponctuel pour les parcs, la réparation des routes et l’usure des voies.\n" +
                    "Inutile pour jouer normalement.\n" +
                    "Emplacement : <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "Cliquez une fois, attendez que l’état affiche Terminé, puis utilisez <Ouvrir le dossier du rapport>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "État du rapport" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "Affiche l’état : Inactif / En attente / En cours / Terminé / Échec.\n" +
                    "Terminé affiche la durée et l’heure de fin." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "Logs de debug détaillés" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "Écrit des détails supplémentaires dans <ParksRoads.log> pour le dépannage.\n" +
                    "À désactiver en jeu normal." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "Ouvrir le log" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "Ouvre <Logs/ParksRoads.log>, ou le dossier Logs si le fichier n’existe pas encore.\n" +
                    "Notepad++ peut servir à lire les fichiers log." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "Ouvrir le dossier du rapport" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "Ouvre le dossier du rapport.\n" +
                    "Ouvrez ensuite <ScanReport-ParksRoads.txt> avec votre éditeur de texte." },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "Inactif" },
                { "PRL_SCAN_QUEUED_FMT", "En attente ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "En cours ({0})" },
                { "PRL_SCAN_DONE_FMT", "Terminé ({0} | {1})" },
                { "PRL_SCAN_FAILED", "Échec" },
                { "PRL_SCAN_FAIL_NO_CITY", "Chargez d’abord une ville" },
                { "PRL_SCAN_UNKNOWN_TIME", "heure inconnue" },
            };
        }

        public void Unload()
        {
        }
    }
}
