// <copyright file="LocaleJA.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleJA.cs
// Japanese (ja-JP) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleJA : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleJA(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "情報" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "公園メンテナンス" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "道路修理" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "車線の劣化" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "情報" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "サポートリンク" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "ステータスレポート / デバッグ" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "デポの車両数" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "公園メンテナンスデポの**最大車両数**を変更します。\n" +
                    "**100%** = バニラ。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "作業容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "公園メンテナンスの**作業容量**を変更します。\n" +
                    "メンテナンス車両が施設に戻るまでに行える総作業量です。\n" +
                    "**100%** = バニラ。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "作業速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "公園メンテナンス車両の作業速度を変更します。\n" +
                    "**100%** = バニラ。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "公園メンテナンスをリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "公園メンテナンスの値を **100%** に戻します。" },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "デポの車両数" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "道路メンテナンスデポの**最大車両数**を変更します。\n" +
                    "値を上げると道路メンテナンス車両を増やせます。\n" +
                    "**100%** = バニラ。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "作業容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "道路メンテナンスの**作業容量**を変更します。\n" +
                    "値を上げるとデポへ戻るまでにより多くの修理作業ができます。\n" +
                    "**100%** = バニラ。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "修理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "道路メンテナンス車両が道路を修理する速度を変更します。\n" +
                    "**100%** = バニラ。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "道路修理をリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "デポ車両数、作業容量、修理速度を **100%** に戻します。" },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "車線劣化 / 道路損傷" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "**時間と交通量**による道路の劣化速度を調整します。\n" +
                    "**5%** = 道路の劣化が大幅に遅くなります。\n" +
                    "**100%** = バニラ。\n" +
                    "**500%** = 道路の劣化が速くなります。\n" +
                    "道路の劣化 / 損傷に使われる車線劣化データを変更します。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "車線劣化をリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "道路修理設定を変えずに、車線劣化を **100%** に戻します。" },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "このModの表示名です。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "現在のModバージョンとビルド種別です。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "MochiのParadox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "River-mochiのParadox Modsページを開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "コミュニティDiscordをブラウザで開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "スキャンレポート" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "公園、道路修理、車線劣化の1回限りのレポートを作成します。\n" +
                    "通常のプレイには不要です。\n" +
                    "保存先: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "1回クリックし、状態が 完了 になるまで待ってから <レポートフォルダーを開く> を使います。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "スキャンレポートの状態" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "状態を表示します: 待機 / キュー済み / 実行中 / 完了 / 失敗。\n" +
                    "完了時は所要時間と完了時刻を表示します。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "詳細デバッグログ" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "トラブルシューティング用の追加情報を <ParksRoads.log> に書き込みます。\n" +
                    "通常のプレイでは無効にしてください。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "ログを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "<Logs/ParksRoads.log> を開きます。まだ無い場合は Logs フォルダーを開きます。\n" +
                    "ログファイルはNotepad++でも確認できます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "レポートフォルダーを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "レポートフォルダーを開きます。\n" +
                    "その後、テキストエディターで <ScanReport-ParksRoads.txt> を開いてください。" },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "待機" },
                { "PRL_SCAN_QUEUED_FMT", "キュー済み ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "実行中 ({0})" },
                { "PRL_SCAN_DONE_FMT", "完了 ({0} | {1})" },
                { "PRL_SCAN_FAILED", "失敗" },
                { "PRL_SCAN_FAIL_NO_CITY", "先に都市を読み込んでください" },
                { "PRL_SCAN_UNKNOWN_TIME", "時刻不明" },
            };
        }

        public void Unload()
        {
        }
    }
}
