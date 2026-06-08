# Internal Systems & Behaviour — Parks + Road Repairs

Quick reference for how **Parks + Road Repairs** works under the hood.
Parks, Road Repair, Road Maintenance, Lane Wear, and Lane Damage reporting parts are split off from the original PublicWorksPlus codebase.

## Overview

| Area / Feature | What it does | Implementation |
|---|---|---|
| **Parks maintenance** | Adjusts park maintenance vehicle/depot behavior. | Uses maintenance prefab data and applies player settings once after load or setting change. |
| **Road repair** | Adjusts road maintenance / repair vehicle behavior. | Uses maintenance vehicle and depot prefab data. |
| **Maintenance depots** | Adjusts how many maintenance vehicles depots can support. | Writes scaled values to `MaintenanceDepotData.m_VehicleCapacity`. |
| **Maintenance workload** | Adjusts how much work maintenance vehicles can perform. | Writes scaled values to maintenance vehicle prefab data. |
| **Lane wear / road wear** | Adjusts how fast roads deteriorate. | Scales `LaneDeteriorationData.m_TimeFactor` and `LaneDeteriorationData.m_TrafficFactor`. |
| **Lane damage status** | Reports lane wear / road deterioration data for checking. | Uses the lane wear probe and prefab scan report. |
| **Status report** | Writes a report for Parks, Road Repair, and Lane Wear only. | `PrefabScanSystem` writes a text report under the mod data folder. |
| **Debug logging** | Optional detailed logging. | Controlled by `EnableDebugLogging` and written through `Mod.s_Log`. |

## Kept systems

These are the main systems that should remain in this split mod:

```text
Systems/MaintenanceSystem.cs
Systems/LaneWearSystem.cs
Systems/Probes/LaneWearProbeSystem.cs
Systems/Probes/PrefabScanState.cs
Systems/Probes/PrefabScanSystem.cs
Systems/Probes/PrefabScanSystem.ReportSections.cs
