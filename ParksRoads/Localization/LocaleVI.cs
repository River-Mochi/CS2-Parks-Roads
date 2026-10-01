// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleVI.cs
// Vietnamese (vi-VN) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleVI : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleVI(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ActionsTab), "Thao tác" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "Giới thiệu" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "Bảo trì công viên" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "Sửa đường" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "Hao mòn làn đường" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "Thông tin" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "Liên kết hỗ trợ" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "Báo cáo trạng thái / gỡ lỗi" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "Số xe tại depot" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "Điều chỉnh **số xe tối đa** của depot bảo trì công viên.\n" +
                    "**100%** = mặc định của game." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "Khối lượng công việc" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Điều chỉnh **khối lượng công việc** của bảo trì công viên.\n" +
                    "Đây là tổng công việc một xe bảo trì có thể làm trước khi quay về tòa nhà.\n" +
                    "**100%** = mặc định của game." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "Tốc độ làm việc" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "Điều chỉnh tốc độ làm việc của xe bảo trì công viên.\n" +
                    "**100%** = mặc định của game." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Đặt lại bảo trì công viên" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Đặt các giá trị bảo trì công viên về **100%**." },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "Số xe tại depot" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "Điều chỉnh **số xe tối đa** của depot bảo trì đường.\n" +
                    "Giá trị cao hơn cho phép nhiều xe bảo trì đường hơn.\n" +
                    "**100%** = mặc định của game." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "Khối lượng công việc" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Điều chỉnh **khối lượng công việc** của bảo trì đường.\n" +
                    "Giá trị cao hơn cho phép xe sửa nhiều hơn trước khi quay về depot.\n" +
                    "**100%** = mặc định của game." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "Tốc độ sửa chữa" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "Điều chỉnh tốc độ xe bảo trì sửa đường.\n" +
                    "**100%** = mặc định của game." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Đặt lại sửa đường" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Đặt số xe depot, khối lượng công việc và tốc độ sửa chữa về **100%**." },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "Hao mòn làn đường / hư hỏng đường" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "Kiểm soát tốc độ xuống cấp của đường do **thời gian và lưu lượng giao thông**.\n" +
                    "**5%** = hao mòn chậm hơn nhiều.\n" +
                    "**100%** = mặc định của game.\n" +
                    "**500%** = hao mòn nhanh hơn.\n" +
                    "Thay đổi dữ liệu xuống cấp làn đường dùng cho hao mòn / hư hỏng đường." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Đặt lại hao mòn làn đường" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Đặt hao mòn làn đường về **100%** mà không thay đổi cài đặt sửa đường." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "Tên hiển thị của mod này." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Phiên bản" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Phiên bản mod hiện tại và loại bản dựng." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mod Paradox của Mochi" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mở trang mod Paradox của River-mochi." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "Mở Discord cộng đồng trong trình duyệt." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "Báo cáo quét" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "Tạo báo cáo một lần cho công viên, sửa đường và hao mòn làn đường.\n" +
                    "Không cần cho gameplay bình thường.\n" +
                    "Vị trí tệp: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "Bấm một lần, chờ trạng thái hiện Hoàn tất rồi dùng <Mở thư mục báo cáo>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "Trạng thái báo cáo quét" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "Hiển thị trạng thái: Chờ / Đã xếp hàng / Đang chạy / Hoàn tất / Thất bại.\n" +
                    "Hoàn tất hiển thị thời lượng và thời gian hoàn tất." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "Nhật ký gỡ lỗi chi tiết" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "Ghi thêm chi tiết vào <ParksRoads.log> để xử lý sự cố.\n" +
                    "Tắt khi chơi bình thường." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "Mở nhật ký" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "Mở <Logs/ParksRoads.log>, hoặc thư mục Logs nếu tệp chưa tồn tại.\n" +
                    "Có thể dùng Notepad++ để xem tệp nhật ký." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "Mở thư mục báo cáo" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "Mở thư mục báo cáo.\n" +
                    "Sau đó mở <ScanReport-ParksRoads.txt> bằng trình soạn thảo văn bản." },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "Chờ" },
                { "PRL_SCAN_QUEUED_FMT", "Đã xếp hàng ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "Đang chạy ({0})" },
                { "PRL_SCAN_DONE_FMT", "Hoàn tất ({0} | {1})" },
                { "PRL_SCAN_FAILED", "Thất bại" },
                { "PRL_SCAN_FAIL_NO_CITY", "Hãy tải thành phố trước" },
                { "PRL_SCAN_UNKNOWN_TIME", "không rõ thời gian" },
            };
        }

        public void Unload()
        {
        }
    }
}
