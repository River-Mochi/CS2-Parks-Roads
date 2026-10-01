// <copyright file="LocaleTH.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTH.cs
// Thai (th-TH) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleTH : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleTH(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ActionsTab), "การตั้งค่า" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "เกี่ยวกับ" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "การบำรุงรักษาสวนสาธารณะ" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "การซ่อมถนน" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "การสึกหรอของถนน" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "ข้อมูล" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "ลิงก์ช่วยเหลือ" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "รายงานสถานะ / ดีบัก" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "ขนาดกองรถของศูนย์" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "ปรับ **จำนวนรถสูงสุด** ของศูนย์บำรุงรักษาสวนสาธารณะ\n" +
                    "**100%** = ค่าเริ่มต้นของเกม" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "ความจุงานต่อรอบ" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "ปรับ **ความจุงานต่อรอบ** ของรถบำรุงรักษาสวนสาธารณะ\n" +
                    "คือปริมาณงานทั้งหมดที่รถทำได้ก่อนต้องกลับอาคาร\n" +
                    "**100%** = ค่าเริ่มต้นของเกม" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "ความเร็วในการทำงาน" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "ปรับความเร็วที่รถบำรุงรักษาสวนสาธารณะทำงาน\n" +
                    "**100%** = ค่าเริ่มต้นของเกม" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "รีเซ็ตการบำรุงรักษาสวน" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)),
                    "รีเซ็ตค่าการบำรุงรักษาสวนสาธารณะกลับเป็น **100%**" },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "ขนาดกองรถของศูนย์" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "ปรับ **จำนวนรถสูงสุด** ของศูนย์บำรุงรักษาถนน\n" +
                    "ค่าที่สูงขึ้นทำให้มีรถบำรุงรักษาถนนได้มากขึ้น\n" +
                    "**100%** = ค่าเริ่มต้นของเกม" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "ความจุงานต่อรอบ" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "ปรับ **ความจุงานต่อรอบ** ของรถบำรุงรักษาถนน\n" +
                    "ค่าที่สูงขึ้นทำให้รถซ่อมถนนได้มากขึ้นก่อนกลับศูนย์\n" +
                    "**100%** = ค่าเริ่มต้นของเกม" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "ความเร็วในการซ่อม" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "ปรับความเร็วที่รถบำรุงรักษาซ่อมถนน\n" +
                    "**100%** = ค่าเริ่มต้นของเกม" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "รีเซ็ตการซ่อมถนน" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)),
                    "รีเซ็ตขนาดกองรถ ความจุงานต่อรอบ และความเร็วในการซ่อมกลับเป็น **100%**" },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "การสึกหรอ / ความเสียหายของถนน" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "ควบคุมความเร็วที่ถนนเสื่อมสภาพจาก **เวลาและการจราจร**\n" +
                    "**5%** = ถนนสึกหรอช้าลงมาก\n" +
                    "**100%** = ค่าเริ่มต้นของเกม\n" +
                    "**500%** = ถนนสึกหรอเร็วขึ้น\n" +
                    "เปลี่ยนข้อมูลการเสื่อมสภาพของเลนสำหรับการสึกหรอ / ความเสียหายของถนน" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "รีเซ็ตการสึกหรอของถนน" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)),
                    "รีเซ็ตการสึกหรอของถนนเป็น **100%** โดยไม่เปลี่ยนการตั้งค่าการซ่อมถนน" },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "ม็อด" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "ชื่อที่แสดงของม็อดนี้" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "เวอร์ชัน" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "เวอร์ชันปัจจุบันของม็อดและประเภทบิลด์" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "ม็อด Paradox ของ Mochi" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "เปิดหน้า Paradox Mods ของ River-mochi" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "เปิด Discord ของชุมชนในเบราว์เซอร์" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "รายงานการสแกน" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "สร้างรายงานครั้งเดียวสำหรับสวนสาธารณะ การซ่อมถนน และการสึกหรอของถนน\n" +
                    "ไม่จำเป็นสำหรับการเล่นตามปกติ\n" +
                    "ตำแหน่งไฟล์: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "คลิกหนึ่งครั้ง รอจนสถานะแสดงว่าเสร็จ แล้วใช้ <เปิดโฟลเดอร์รายงาน>" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "สถานะรายงานการสแกน" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "แสดงสถานะการสแกน: ว่าง / อยู่ในคิว / กำลังทำงาน / เสร็จ / ล้มเหลว\n" +
                    "เมื่อเสร็จจะแสดงระยะเวลาและเวลาที่เสร็จสิ้น" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "บันทึกดีบักแบบละเอียด" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "เขียนรายละเอียดเพิ่มเติมลงใน <ParksRoads.log> เพื่อช่วยแก้ปัญหา\n" +
                    "ปิดไว้สำหรับการเล่นตามปกติ" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "เปิดบันทึก" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "เปิด <Logs/ParksRoads.log> หรือโฟลเดอร์ Logs หากยังไม่มีไฟล์\n" +
                    "สามารถใช้ Notepad++ เพื่อดูไฟล์บันทึกได้"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "เปิดโฟลเดอร์รายงาน" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "เปิดโฟลเดอร์รายงาน\n" +
                    "จากนั้นเปิด <ScanReport-ParksRoads.txt> ด้วยโปรแกรมแก้ไขข้อความ" },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "ว่าง" },
                { "PRL_SCAN_QUEUED_FMT", "อยู่ในคิว ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "กำลังทำงาน ({0})" },
                { "PRL_SCAN_DONE_FMT", "เสร็จ ({0} | {1})" },
                { "PRL_SCAN_FAILED", "ล้มเหลว" },
                { "PRL_SCAN_FAIL_NO_CITY", "โหลดเมืองก่อน" },
                { "PRL_SCAN_UNKNOWN_TIME", "ไม่ทราบเวลา" },
            };
        }

        public void Unload()
        {
        }
    }
}
