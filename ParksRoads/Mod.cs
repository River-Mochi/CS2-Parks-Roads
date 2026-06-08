// File: Mod.cs
// Entrypoint: registers settings, locales, and the ECS systems.

namespace ParksRoads
{
    using Colossal;                  // IDictionarySource
    using Colossal.IO.AssetDatabase; // AssetDatabase.LoadSettings
    using Colossal.Localization;     // LocalizationManager
    using Colossal.Logging;          // ILog
    using CS2Shared.RiverMochi;      // LogUtils
    using Game;                      // UpdateSystem, GameMode, SystemUpdatePhase
    using Game.Modding;              // IMod
    using Game.SceneFlow;            // GameManager
    using System;                    // Exception
    using System.Reflection;         // Assembly

    /// <summary>Mod entry point: registers settings, locales, and ECS systems.</summary>
    public sealed class Mod : IMod
    {
        public const string ModName = "Parks + Road Repairs";
        public const string ShortName = "Parks + Road Repairs";
        public const string ModId = "ParksRoads";
        public const string ModTag = "[ParksRoads]";

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        private static bool s_BannerLogged;

        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        public static Setting? Settings;

        public void OnLoad(UpdateSystem updateSystem)
        {
            LogUtils.Configure(ModId, s_Log);

            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                LogUtils.Info(s_Log, () => $"{ModName} v{ModVersion} OnLoad");
            }

            // Settings first so locale labels can resolve.
            Setting setting = new(this);
            Settings = setting;

            // Register ALL languages later when the split mod is stable.
            AddLocaleSource("en-US", new LocaleEN(setting));
            // AddLocaleSource("fr-FR", new LocaleFR(setting));
            // AddLocaleSource("es-ES", new LocaleES(setting));
            // AddLocaleSource("de-DE", new LocaleDE(setting));
            // AddLocaleSource("it-IT", new LocaleIT(setting));
            // AddLocaleSource("ja-JP", new LocaleJA(setting));
            // AddLocaleSource("ko-KR", new LocaleKO(setting));
            // AddLocaleSource("pl-PL", new LocalePL(setting));
            // AddLocaleSource("pt-BR", new LocalePT_BR(setting));
            // AddLocaleSource("zh-HANS", new LocaleZH_CN(setting));    // Simplified Chinese
            // AddLocaleSource("zh-HANT", new LocaleZH_HANT(setting));  // Traditional Chinese
            // AddLocaleSource("th-TH", new LocaleTH(setting));         // Thai
            // AddLocaleSource("vi-VN", new LocaleVI(setting));         // Vietnamese
            // AddLocaleSource("tr-TR", new LocaleTR(setting));         // Turkish
            // AddLocaleSource("pt-PT", new LocalePT_PT(setting));      // European Portuguese

            // Load settings (.coc) into the instance.
            // The default instance passed here provides defaults for missing fields.
            AssetDatabase.global.LoadSettings(ModId, setting, new Setting(this));

            // Repair missing/out-of-range/invalid values in-memory (no auto-save).
            setting.SanitizeAfterLoad();

            setting.RegisterInOptionsUI();

            // Parks + Road Repairs systems.
            updateSystem.UpdateAfter<MaintenanceSystem>(SystemUpdatePhase.PrefabUpdate);
            updateSystem.UpdateAfter<LaneWearSystem>(SystemUpdatePhase.PrefabUpdate);

            // Prefab scan: must work even while Options UI is open.
            updateSystem.UpdateAt<PrefabScanSystem>(SystemUpdatePhase.PrefabUpdate);

#if DEBUG
            // Debug probe: logs LaneCondition.m_Wear deltas/runtime lane wear info.
            updateSystem.UpdateAt<LaneWearProbeSystem>(SystemUpdatePhase.GameSimulation);
#endif

            LogUtils.Info(s_Log, () => $"{ModId}.{nameof(OnLoad)} Completed.");
        }

        public void OnDispose()
        {
            LogUtils.Info(s_Log, () => "OnDispose");

            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();
                Settings = null;
            }
        }

        //---------------
        // HELPERS
        //---------------

        private static void AddLocaleSource(string localeId, IDictionarySource source)
        {
            if (string.IsNullOrEmpty(localeId))
            {
                return;
            }

            LocalizationManager? lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                LogUtils.Warn(s_Log, () => $"AddLocaleSource: No LocalizationManager; cannot add source for '{localeId}'.");
                return;
            }

            try
            {
                lm.AddSource(localeId, source);
            }
            catch (Exception ex)
            {
                LogUtils.Warn(s_Log, () => $"AddLocaleSource: AddSource for '{localeId}' failed: {ex.GetType().Name}: {ex.Message}");
            }
        }

        internal static string L(string id, string fallback)
        {
            try
            {
                LocalizationManager? lm = GameManager.instance?.localizationManager;
                if (lm != null &&
                    lm.activeDictionary != null &&
                    lm.activeDictionary.TryGetValue(id, out string result))
                {
                    return result;
                }
            }
            catch
            {
            }

            return fallback;
        }
    }
}
