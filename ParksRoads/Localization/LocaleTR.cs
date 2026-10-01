// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleTR.cs
// Turkish (tr-TR) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleTR : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleTR(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ActionsTab), "Eylemler" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "Hakkında" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "Park bakımı" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "Yol onarımı" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "Şerit aşınması" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "Bilgi" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "Destek bağlantıları" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "Durum raporu / hata ayıklama" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "Depo filo boyutu" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "Park bakım deposunun **maksimum araç sayısını** ölçekler.\n" +
                    "**100%** = oyun varsayılanı." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "Çalışma kapasitesi" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Park bakımının **çalışma kapasitesini** ölçekler.\n" +
                    "Bu, bir bakım aracının binasına dönmeden önce yapabileceği toplam iştir.\n" +
                    "**100%** = oyun varsayılanı." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "Araç çalışma hızı" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "Park bakım araçlarının çalışma hızını ölçekler.\n" +
                    "**100%** = oyun varsayılanı." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Park bakımını sıfırla" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Park bakım değerlerini **100%** olarak sıfırlar." },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "Depo filo boyutu" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "Yol bakım deposunun **maksimum araç sayısını** ölçekler.\n" +
                    "Daha yüksek değerler daha fazla yol bakım aracına izin verir.\n" +
                    "**100%** = oyun varsayılanı." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "Çalışma kapasitesi" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Yol bakımının **çalışma kapasitesini** ölçekler.\n" +
                    "Daha yüksek değerler araçların depoya dönmeden önce daha fazla onarım yapmasını sağlar.\n" +
                    "**100%** = oyun varsayılanı." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "Onarım hızı" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "Yol bakım araçlarının yolları onarma hızını ölçekler.\n" +
                    "**100%** = oyun varsayılanı." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Yol onarımını sıfırla" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Depo filosunu, çalışma kapasitesini ve onarım hızını **100%** olarak sıfırlar." },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "Şerit aşınması / yol hasarı" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "Yolların **zaman ve trafik** nedeniyle ne kadar hızlı bozulduğunu kontrol eder.\n" +
                    "**5%** = çok daha yavaş yol aşınması.\n" +
                    "**100%** = oyun varsayılanı.\n" +
                    "**500%** = daha hızlı yol aşınması.\n" +
                    "Yol aşınması / hasarı için kullanılan şerit bozulma verilerini değiştirir." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Şerit aşınmasını sıfırla" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Yol onarım ayarlarını değiştirmeden şerit aşınmasını **100%** olarak sıfırlar." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "Bu modun görünen adı." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Sürüm" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Mevcut mod sürümü ve derleme türü." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mochi'nin Paradox modları" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "River-mochi'nin Paradox modları sayfasını açar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "Topluluk Discord'unu tarayıcıda açar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "Tarama raporu" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "Parklar, yol onarımı ve şerit aşınması için tek seferlik bir rapor oluşturur.\n" +
                    "Normal oyun için gerekli değildir.\n" +
                    "Dosya konumu: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "Bir kez tıklayın, durum Tamamlandı olana kadar bekleyin, sonra <Rapor klasörünü aç> seçeneğini kullanın." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "Tarama raporu durumu" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "Durumu gösterir: Boşta / Kuyrukta / Çalışıyor / Tamamlandı / Başarısız.\n" +
                    "Tamamlandı, süreyi ve bitiş zamanını gösterir." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "Ayrıntılı hata ayıklama günlükleri" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "Sorun giderme için <ParksRoads.log> dosyasına ek ayrıntılar yazar.\n" +
                    "Normal oyunda kapatın." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "Günlüğü aç" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "<Logs/ParksRoads.log> dosyasını veya dosya henüz yoksa Logs klasörünü açar.\n" +
                    "Günlük dosyalarını Notepad++ ile görüntüleyebilirsiniz." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "Rapor klasörünü aç" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "Rapor klasörünü açar.\n" +
                    "Ardından <ScanReport-ParksRoads.txt> dosyasını metin düzenleyicinizle açın." },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "Boşta" },
                { "PRL_SCAN_QUEUED_FMT", "Kuyrukta ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "Çalışıyor ({0})" },
                { "PRL_SCAN_DONE_FMT", "Tamamlandı ({0} | {1})" },
                { "PRL_SCAN_FAILED", "Başarısız" },
                { "PRL_SCAN_FAIL_NO_CITY", "Önce bir şehir yükleyin" },
                { "PRL_SCAN_UNKNOWN_TIME", "bilinmeyen zaman" },
            };
        }

        public void Unload()
        {
        }
    }
}
