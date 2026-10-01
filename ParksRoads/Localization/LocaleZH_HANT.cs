// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleZH_HANT.cs
// Traditional Chinese (zh-HANT) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleZH_HANT : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleZH_HANT(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "關於" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "公園維護" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "道路維修" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "車道磨損" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "資訊" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "支援連結" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "狀態報告 / 偵錯" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "維護站車隊規模" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "調整公園維護站的**最大車輛數**。\n" +
                    "**100%** = 遊戲預設。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "單次作業容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "調整公園維護的**作業容量**。\n" +
                    "這是維護車輛返回建築前可完成的總工作量。\n" +
                    "**100%** = 遊戲預設。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "車輛作業速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "調整公園維護車輛的作業速度。\n" +
                    "**100%** = 遊戲預設。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "重設公園維護" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "將公園維護數值重設為 **100%**。" },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "維護站車隊規模" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "調整道路維護站的**最大車輛數**。\n" +
                    "數值越高，可用的道路維護車輛越多。\n" +
                    "**100%** = 遊戲預設。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "單次作業容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "調整道路維護的**作業容量**。\n" +
                    "數值越高，車輛返回維護站前可完成的維修工作越多。\n" +
                    "**100%** = 遊戲預設。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "維修速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "調整道路維護車輛維修道路的速度。\n" +
                    "**100%** = 遊戲預設。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "重設道路維修" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "將維護站車隊規模、作業容量和維修速度重設為 **100%**。" },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "車道磨損 / 道路損壞" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "控制道路因**時間和交通流量**而劣化的速度。\n" +
                    "**5%** = 道路磨損慢很多。\n" +
                    "**100%** = 遊戲預設。\n" +
                    "**500%** = 道路磨損更快。\n" +
                    "修改用於道路磨損 / 損壞的車道劣化資料。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "重設車道磨損" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "將車道磨損重設為 **100%**，不會變更道路維修設定。" },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "此模組的顯示名稱。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "目前模組版本和建置類型。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mochi 的 Paradox 模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "開啟 River-mochi 的 Paradox 模組頁面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "在瀏覽器中開啟社群 Discord。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "掃描報告" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "建立一次性的公園、道路維修和車道磨損報告。\n" +
                    "一般遊戲不需要使用。\n" +
                    "檔案位置：<ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "點擊一次，等待狀態顯示 完成，然後使用 <開啟報告資料夾>。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "掃描報告狀態" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "顯示狀態：閒置 / 已排入佇列 / 執行中 / 完成 / 失敗。\n" +
                    "完成時會顯示耗時和完成時間。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "詳細偵錯記錄" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "將額外的疑難排解資訊寫入 <ParksRoads.log>。\n" +
                    "一般遊戲時請關閉。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "開啟記錄" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "開啟 <Logs/ParksRoads.log>；如果檔案尚不存在，則開啟 Logs 資料夾。\n" +
                    "可使用 Notepad++ 檢視記錄檔。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "開啟報告資料夾" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "開啟報告資料夾。\n" +
                    "然後使用文字編輯器開啟 <ScanReport-ParksRoads.txt>。" },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "閒置" },
                { "PRL_SCAN_QUEUED_FMT", "已排入佇列 ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "執行中 ({0})" },
                { "PRL_SCAN_DONE_FMT", "完成 ({0} | {1})" },
                { "PRL_SCAN_FAILED", "失敗" },
                { "PRL_SCAN_FAIL_NO_CITY", "請先載入城市" },
                { "PRL_SCAN_UNKNOWN_TIME", "時間未知" },
            };
        }

        public void Unload()
        {
        }
    }
}
