// <copyright file="LocaleUK.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleUK.cs
// Ukrainian (uk-UA) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocaleUK : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocaleUK(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ActionsTab), "Дії" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "Про мод" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "Обслуговування парків" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "Ремонт доріг" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "Зношення смуг" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "Інформація" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "Посилання підтримки" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "Звіт стану / налагодження" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "Розмір парку депо" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "Змінює **максимальну кількість транспорту** депо обслуговування парків.\n" +
                    "**100%** = стандарт гри." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "Обсяг роботи за зміну" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Змінює **обсяг роботи за зміну** для обслуговування парків.\n" +
                    "Це загальний обсяг роботи, який машина обслуговування може виконати до повернення у свою будівлю.\n" +
                    "**100%** = стандарт гри." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "Швидкість роботи машин" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "Змінює швидкість роботи машин обслуговування парків.\n" +
                    "**100%** = стандарт гри." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Скинути обслуговування парків" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)),
                    "Повернути значення обслуговування парків до **100%**." },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "Розмір парку депо" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "Змінює **максимальну кількість транспорту** депо обслуговування доріг.\n" +
                    "Вищі значення дозволяють використовувати більше машин ремонту доріг.\n" +
                    "**100%** = стандарт гри." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "Обсяг роботи за зміну" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Змінює **обсяг роботи за зміну** для ремонту доріг.\n" +
                    "Вищі значення дозволяють машинам виконати більше ремонту до повернення в депо.\n" +
                    "**100%** = стандарт гри." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "Швидкість ремонту" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "Змінює швидкість, з якою машини обслуговування ремонтують дороги.\n" +
                    "**100%** = стандарт гри." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Скинути ремонт доріг" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)),
                    "Повернути розмір парку депо, обсяг роботи за зміну та швидкість ремонту до **100%**." },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "Зношення смуг / пошкодження доріг" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "Керує швидкістю погіршення стану доріг через **час і дорожній рух**.\n" +
                    "**5%** = значно повільніше зношення доріг.\n" +
                    "**100%** = стандарт гри.\n" +
                    "**500%** = швидше зношення доріг.\n" +
                    "Змінює дані погіршення стану смуг для зношення / пошкодження доріг." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Скинути зношення смуг" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)),
                    "Повернути зношення смуг до **100%**, не змінюючи налаштування ремонту доріг." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Мод" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "Відображувана назва цього мода." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Версія" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Поточна версія мода та тип збірки." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Моди Mochi на Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Відкрити сторінку модів River-mochi на Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "Відкрити Discord спільноти у браузері." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "Звіт сканування" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "Створює одноразовий звіт для парків, ремонту доріг і зношення смуг.\n" +
                    "Не потрібен для звичайної гри.\n" +
                    "Розташування файла: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "Натисніть один раз, дочекайтеся стану «Готово», потім використайте <Відкрити папку звіту>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "Стан звіту сканування" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "Показує стан сканування: Очікування / У черзі / Виконується / Готово / Помилка.\n" +
                    "Після завершення показує тривалість і час завершення." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "Докладний журнал налагодження" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "Записує додаткові подробиці в <ParksRoads.log> для пошуку проблем.\n" +
                    "Вимкніть для звичайної гри." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "Відкрити журнал" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "Відкрити <Logs/ParksRoads.log> або папку Logs, якщо файла ще немає.\n" +
                    "Для перегляду журналів можна використовувати Notepad++."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "Відкрити папку звіту" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "Відкрити папку звіту.\n" +
                    "Потім відкрийте <ScanReport-ParksRoads.txt> у текстовому редакторі." },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "Очікування" },
                { "PRL_SCAN_QUEUED_FMT", "У черзі ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "Виконується ({0})" },
                { "PRL_SCAN_DONE_FMT", "Готово ({0} | {1})" },
                { "PRL_SCAN_FAILED", "Помилка" },
                { "PRL_SCAN_FAIL_NO_CITY", "Спочатку завантажте місто" },
                { "PRL_SCAN_UNKNOWN_TIME", "невідомий час" },
            };
        }

        public void Unload()
        {
        }
    }
}
