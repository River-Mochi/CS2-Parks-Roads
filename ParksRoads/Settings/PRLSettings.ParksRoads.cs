// <copyright file="PRLSettings.ParksRoads.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Settings/PRLSettings.ParksRoads.cs
// Purpose: Parks/Roads settings (maintenance + road wear).

namespace ParksRoads
{
    using CS2Shared.RiverMochi;
    using Game.Settings;     // Settings UI attributes
    using Game.UI;           // Unit

    public partial class PRLSettings
    {
        // ------------------------
        // Parks-Roads (percent)
        // ------------------------

        [SettingsUISlider(min = MaintenanceMinPercent, max = MaintenanceMaxPercent, step = MaintenanceStepPercent, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, ParkMaintenanceGroup)]
        public float ParkMaintenanceDepotScalar { get; set; }

        [SettingsUISlider(min = MaintenanceMinPercent, max = MaintenanceMaxPercent, step = MaintenanceStepPercent, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, ParkMaintenanceGroup)]
        public float ParkMaintenanceVehicleCapacityScalar { get; set; }

        [SettingsUISlider(min = MaintenanceMinPercent, max = MaintenanceMaxPercent, step = MaintenanceStepPercent, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, ParkMaintenanceGroup)]
        public float ParkMaintenanceVehicleRateScalar { get; set; }

        [SettingsUIButtonGroup(ParkMaintenanceGroup)]
        [SettingsUIButton]
        [SettingsUISection(ActionsTab, ParkMaintenanceGroup)]
        public bool ResetParkMaintenanceToVanillaButton
        {
            set
            {
                if (!value) return;

                ParkMaintenanceDepotScalar = kVanillaPercent;
                ParkMaintenanceVehicleCapacityScalar = kVanillaPercent;
                ParkMaintenanceVehicleRateScalar = kVanillaPercent;

                ApplyAndSave();
            }
        }

        [SettingsUISlider(min = MaintenanceMinPercent, max = MaintenanceMaxPercent, step = MaintenanceStepPercent, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, RoadMaintenanceGroup)]
        public float RoadMaintenanceDepotScalar { get; set; }

        [SettingsUISlider(min = MaintenanceMinPercent, max = MaintenanceMaxPercent, step = MaintenanceStepPercent, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, RoadMaintenanceGroup)]
        public float RoadMaintenanceVehicleCapacityScalar { get; set; }

        [SettingsUISlider(min = MaintenanceMinPercent, max = MaintenanceMaxPercent, step = MaintenanceStepPercent, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, RoadMaintenanceGroup)]
        public float RoadMaintenanceVehicleRateScalar { get; set; }

        [SettingsUIButtonGroup(RoadMaintenanceGroup)]
        [SettingsUIButton]
        [SettingsUISection(ActionsTab, RoadMaintenanceGroup)]
        public bool ResetRoadMaintenanceToVanillaButton
        {
            set
            {
                if (!value) return;

                RoadMaintenanceDepotScalar = kVanillaPercent;
                RoadMaintenanceVehicleCapacityScalar = kVanillaPercent;
                RoadMaintenanceVehicleRateScalar = kVanillaPercent;
                ApplyAndSave();
            }
        }

        [SettingsUISlider(min = RoadWearMinPercent, max = RoadWearMaxPercent, step = RoadWearStepPercent, scalarMultiplier = 1, unit = Unit.kPercentage)]
        [SettingsUISection(ActionsTab, LaneWearGroup)]
        public float RoadWearScalar { get; set; }

        [SettingsUIButtonGroup(LaneWearGroup)]
        [SettingsUIButton]
        [SettingsUISection(ActionsTab, LaneWearGroup)]
        public bool ResetLaneWearToVanillaButton
        {
            set
            {
                if (!value) return;

                RoadWearScalar = kVanillaPercent;
                ApplyAndSave();
            }
        }

        partial void SetDefaults_ParksRoads()
        {
            ParkMaintenanceDepotScalar = kVanillaPercent;
            ParkMaintenanceVehicleCapacityScalar = kVanillaPercent;
            ParkMaintenanceVehicleRateScalar = kVanillaPercent;

            RoadMaintenanceDepotScalar = kVanillaPercent;
            RoadMaintenanceVehicleCapacityScalar = kVanillaPercent;
            RoadMaintenanceVehicleRateScalar = kVanillaPercent;

            RoadWearScalar = kVanillaPercent;
        }
    }
}
