// <copyright file="LocaleZH_CN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_CN.cs
// Simplified Chinese (zh-HANS) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleZH_CN : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleZH_CN(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "关于" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "公园维护" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "道路维修" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "车道磨损" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "信息" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "支持链接" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "状态报告 / 调试" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "维护站车队规模" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "调整公园维护站的**最大车辆数**。\n" +
                    "**100%** = 游戏默认。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "单次作业容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "调整公园维护的**作业容量**。\n" +
                    "这是维护车辆返回建筑前可完成的总工作量。\n" +
                    "**100%** = 游戏默认。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "车辆作业速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "调整公园维护车辆的作业速度。\n" +
                    "**100%** = 游戏默认。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "重置公园维护" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "将公园维护数值重置为 **100%**。" },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "维护站车队规模" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "调整道路维护站的**最大车辆数**。\n" +
                    "数值越高，可用的道路维护车辆越多。\n" +
                    "**100%** = 游戏默认。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "单次作业容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "调整道路维护的**作业容量**。\n" +
                    "数值越高，车辆返回维护站前可完成的维修工作越多。\n" +
                    "**100%** = 游戏默认。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "维修速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "调整道路维护车辆维修道路的速度。\n" +
                    "**100%** = 游戏默认。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "重置道路维修" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "将维护站车队规模、作业容量和维修速度重置为 **100%**。" },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "车道磨损 / 道路损坏" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "控制道路因**时间和交通流量**而劣化的速度。\n" +
                    "**5%** = 道路磨损慢很多。\n" +
                    "**100%** = 游戏默认。\n" +
                    "**500%** = 道路磨损更快。\n" +
                    "修改用于道路磨损 / 损坏的车道劣化数据。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "重置车道磨损" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "将车道磨损重置为 **100%**，不会更改道路维修设置。" },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "此模组的显示名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "当前模组版本和构建类型。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mochi 的 Paradox 模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "打开 River-mochi 的 Paradox 模组页面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "在浏览器中打开社区 Discord。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "扫描报告" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "生成一次性的公园、道路维修和车道磨损报告。\n" +
                    "正常游戏不需要使用。\n" +
                    "文件位置：<ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "点击一次，等待状态显示 完成，然后使用 <打开报告文件夹>。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "扫描报告状态" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "显示状态：空闲 / 已排队 / 运行中 / 完成 / 失败。\n" +
                    "完成时会显示耗时和完成时间。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "详细调试日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "将额外的故障排查信息写入 <ParksRoads.log>。\n" +
                    "正常游戏时请关闭。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "打开日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "打开 <Logs/ParksRoads.log>；如果文件尚不存在，则打开 Logs 文件夹。\n" +
                    "可以使用 Notepad++ 查看日志文件。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "打开报告文件夹" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "打开报告文件夹。\n" +
                    "然后使用文本编辑器打开 <ScanReport-ParksRoads.txt>。" },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "空闲" },
                { "PRL_SCAN_QUEUED_FMT", "已排队 ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "运行中 ({0})" },
                { "PRL_SCAN_DONE_FMT", "完成 ({0} | {1})" },
                { "PRL_SCAN_FAILED", "失败" },
                { "PRL_SCAN_FAIL_NO_CITY", "请先加载城市" },
                { "PRL_SCAN_UNKNOWN_TIME", "时间未知" },
            };
        }

        public void Unload()
        {
        }
    }
}
