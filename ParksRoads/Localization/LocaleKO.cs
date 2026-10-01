// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleKO.cs
// Korean (ko-KR) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleKO : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleKO(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ActionsTab), "작업" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "정보" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "공원 유지보수" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "도로 수리" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "차선 마모" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "정보" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "지원 링크" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "상태 보고서 / 디버그" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "차고 차량 수" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "공원 유지보수 차고의 **최대 차량 수**를 조정합니다.\n" +
                    "**100%** = 기본값." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "작업 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "공원 유지보수의 **작업 용량**을 조정합니다.\n" +
                    "유지보수 차량이 건물로 돌아가기 전에 처리할 수 있는 총 작업량입니다.\n" +
                    "**100%** = 기본값." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "작업 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "공원 유지보수 차량의 작업 속도를 조정합니다.\n" +
                    "**100%** = 기본값." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "공원 유지보수 초기화" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "공원 유지보수 값을 **100%**로 되돌립니다." },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "차고 차량 수" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "도로 유지보수 차고의 **최대 차량 수**를 조정합니다.\n" +
                    "값을 높이면 더 많은 도로 유지보수 차량을 사용할 수 있습니다.\n" +
                    "**100%** = 기본값." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "작업 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "도로 유지보수의 **작업 용량**을 조정합니다.\n" +
                    "값을 높이면 차고로 돌아가기 전에 더 많은 수리 작업을 할 수 있습니다.\n" +
                    "**100%** = 기본값." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "수리 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "도로 유지보수 차량이 도로를 수리하는 속도를 조정합니다.\n" +
                    "**100%** = 기본값." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "도로 수리 초기화" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "차고 차량 수, 작업 용량, 수리 속도를 **100%**로 되돌립니다." },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "차선 마모 / 도로 손상" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "**시간과 교통량**에 따른 도로 열화 속도를 조정합니다.\n" +
                    "**5%** = 도로 마모가 훨씬 느려집니다.\n" +
                    "**100%** = 기본값.\n" +
                    "**500%** = 도로 마모가 빨라집니다.\n" +
                    "도로 마모 / 손상에 사용되는 차선 열화 데이터를 변경합니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "차선 마모 초기화" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "도로 수리 설정은 그대로 두고 차선 마모만 **100%**로 되돌립니다." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "이 모드의 표시 이름입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "현재 모드 버전과 빌드 유형입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mochi의 Paradox 모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "River-mochi의 Paradox 모드 페이지를 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "커뮤니티 Discord를 브라우저에서 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "스캔 보고서" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "공원, 도로 수리, 차선 마모에 대한 일회성 보고서를 만듭니다.\n" +
                    "일반 플레이에는 필요하지 않습니다.\n" +
                    "파일 위치: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "한 번 클릭하고 상태가 완료가 될 때까지 기다린 뒤 <보고서 폴더 열기>를 사용하세요." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "스캔 보고서 상태" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "상태를 표시합니다: 대기 / 대기열 / 실행 중 / 완료 / 실패.\n" +
                    "완료에서는 소요 시간과 완료 시각을 표시합니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "상세 디버그 로그" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "문제 해결을 위한 추가 정보를 <ParksRoads.log>에 기록합니다.\n" +
                    "일반 플레이에서는 끄세요." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "로그 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "<Logs/ParksRoads.log>를 엽니다. 파일이 아직 없으면 Logs 폴더를 엽니다.\n" +
                    "Notepad++로 로그 파일을 볼 수 있습니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "보고서 폴더 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "보고서 폴더를 엽니다.\n" +
                    "그다음 텍스트 편집기로 <ScanReport-ParksRoads.txt>를 여세요." },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "대기" },
                { "PRL_SCAN_QUEUED_FMT", "대기열 ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "실행 중 ({0})" },
                { "PRL_SCAN_DONE_FMT", "완료 ({0} | {1})" },
                { "PRL_SCAN_FAILED", "실패" },
                { "PRL_SCAN_FAIL_NO_CITY", "먼저 도시를 불러오세요" },
                { "PRL_SCAN_UNKNOWN_TIME", "알 수 없는 시간" },
            };
        }

        public void Unload()
        {
        }
    }
}
