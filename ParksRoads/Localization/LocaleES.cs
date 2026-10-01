// <copyright file="LocaleES.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleES.cs
// Spanish (es-ES) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleES : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleES(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ActionsTab), "Acciones" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "Acerca de" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "Mantenimiento de parques" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "Reparación de carreteras" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "Desgaste de carriles" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "Información" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "Enlaces de soporte" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "Informe de estado / depuración" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "Tamaño de flota del depósito" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "Ajusta el **máximo de vehículos** del depósito de mantenimiento de parques.\n" +
                    "**100%** = juego base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "Capacidad de trabajo" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Ajusta la **capacidad de trabajo** del mantenimiento de parques.\n" +
                    "Es el trabajo total que puede hacer un vehículo de mantenimiento antes de volver a su edificio.\n" +
                    "**100%** = juego base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "Ritmo de trabajo" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "Ajusta la velocidad de trabajo de los vehículos de mantenimiento de parques.\n" +
                    "**100%** = juego base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Restablecer mantenimiento de parques" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Restablece los valores de mantenimiento de parques a **100%**." },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "Tamaño de flota del depósito" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "Ajusta el **máximo de vehículos** del depósito de mantenimiento vial.\n" +
                    "Los valores más altos permiten más vehículos de mantenimiento vial.\n" +
                    "**100%** = juego base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "Capacidad de trabajo" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Ajusta la **capacidad de trabajo** del mantenimiento vial.\n" +
                    "Los valores más altos permiten hacer más reparaciones antes de volver al depósito.\n" +
                    "**100%** = juego base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "Ritmo de reparación" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "Ajusta la velocidad a la que los vehículos de mantenimiento reparan las carreteras.\n" +
                    "**100%** = juego base." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Restablecer reparación de carreteras" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Restablece la flota del depósito, la capacidad de trabajo y el ritmo de reparación a **100%**." },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "Desgaste de carriles / daños en carretera" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "Controla la velocidad de deterioro de las carreteras por **tiempo y tráfico**.\n" +
                    "**5%** = desgaste mucho más lento.\n" +
                    "**100%** = juego base.\n" +
                    "**500%** = desgaste más rápido.\n" +
                    "Modifica los datos de deterioro de carriles para el desgaste / daño de carreteras." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Restablecer desgaste de carriles" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Restablece el desgaste de carriles a **100%** sin cambiar los ajustes de reparación." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "Nombre visible de este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Versión actual del mod y tipo de compilación." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mods de Mochi en Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Abre la página de mods de River-mochi en Paradox." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "Abre el Discord de la comunidad en el navegador." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "Informe de escaneo" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "Crea un informe único de parques, reparación de carreteras y desgaste de carriles.\n" +
                    "No es necesario para jugar normalmente.\n" +
                    "Ubicación: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "Haz clic una vez, espera a que el estado muestre Hecho y usa <Abrir carpeta del informe>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "Estado del informe" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "Muestra el estado: Inactivo / En cola / Ejecutando / Hecho / Error.\n" +
                    "Hecho muestra la duración y la hora de finalización." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "Registros de depuración detallados" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "Escribe detalles extra en <ParksRoads.log> para solucionar problemas.\n" +
                    "Desactívalo para jugar normalmente." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "Abrir registro" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "Abre <Logs/ParksRoads.log> o la carpeta Logs si el archivo aún no existe.\n" +
                    "Puedes usar Notepad++ para ver los registros." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "Abrir carpeta del informe" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "Abre la carpeta del informe.\n" +
                    "Después abre <ScanReport-ParksRoads.txt> con tu editor de texto." },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "Inactivo" },
                { "PRL_SCAN_QUEUED_FMT", "En cola ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "Ejecutando ({0})" },
                { "PRL_SCAN_DONE_FMT", "Hecho ({0} | {1})" },
                { "PRL_SCAN_FAILED", "Error" },
                { "PRL_SCAN_FAIL_NO_CITY", "Carga una ciudad primero" },
                { "PRL_SCAN_UNKNOWN_TIME", "hora desconocida" },
            };
        }

        public void Unload()
        {
        }
    }
}
