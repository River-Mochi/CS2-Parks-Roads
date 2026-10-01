// <copyright file="Mod.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Mod.cs
// Entrypoint: registers settings, locales, and the ECS systems.

namespace ParksRoads
{
    using System;                    // Exception
    using System.Reflection;         // Assembly
    using Colossal;                  // IDictionarySource
    using Colossal.IO.AssetDatabase; // AssetDatabase.LoadSettings
    using Colossal.Localization;     // LocalizationManager
    using Colossal.Logging;          // ILog
    using CS2Shared.RiverMochi;      // LogUtils
    using Game;                      // UpdateSystem, GameMode, SystemUpdatePhase
    using Game.Modding;              // IMod
    using Game.SceneFlow;            // GameManager

    /// <summary>Mod entry point: registers settings, locales, and ECS systems.</summary>
    public sealed class Mod : IMod
    {
        public const string ModName = "Parks, Roads & Lane Wear";
        public const string ShortName = "Parks, Roads & Lane Wear";
        public const string ModId = "ParksRoads";
        public const string ModTag = "[ParksRoads]";

#if DEBUG
        private const string kBuildType = "DEBUG";
#else
        private const string kBuildType = "RELEASE";
#endif

        public static string BuildDisplayName => kBuildType == "RELEASE" ? "Release" : "Debug";

        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        private static bool s_BannerLogged;

        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        public static PRLSettings? Settings;

        public void OnLoad(UpdateSystem updateSystem)
        {
            ShellOpen.Configure(s_Log, ModId, ModTag);

            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                LogUtils.Info(s_Log, () => $"{ModName} {ModTag} v{ModVersion} [{kBuildType}] OnLoad");
            }

            // Settings first so locale labels can resolve.
            PRLSettings setting = new(this);
            Settings = setting;

            AddLocaleSource("en-US", new LocaleEN(setting));
            AddLocaleSource("de-DE", new LocaleDE(setting));
            AddLocaleSource("es-ES", new LocaleES(setting));
            AddLocaleSource("fr-FR", new LocaleFR(setting));
            AddLocaleSource("it-IT", new LocaleIT(setting));
            AddLocaleSource("ja-JP", new LocaleJA(setting));
            AddLocaleSource("ko-KR", new LocaleKO(setting));
            AddLocaleSource("nl-NL", new LocaleNL(setting));
            AddLocaleSource("pl-PL", new LocalePL(setting));
            AddLocaleSource("pt-BR", new LocalePT_BR(setting));
            AddLocaleSource("pt-PT", new LocalePT_PT(setting));
            AddLocaleSource("tr-TR", new LocaleTR(setting));
            AddLocaleSource("vi-VN", new LocaleVI(setting));
            AddLocaleSource("zh-HANS", new LocaleZH_CN(setting));
            AddLocaleSource("zh-HANT", new LocaleZH_HANT(setting));

            // Load settings (.coc) into the instance.
            // default instance passed here provides defaults for missing fields.
            AssetDatabase.global.LoadSettings(ModId, setting, new PRLSettings(this));

            // Repair missing/out-of-range/invalid values in-memory (no auto-save).
            setting.SanitizeAfterLoad();

            setting.RegisterInOptionsUI();

            // Park maintenance, road maintenance, and lane wear systems.
            updateSystem.UpdateAfter<MaintenanceSystem>(SystemUpdatePhase.PrefabUpdate);
            updateSystem.UpdateAfter<LaneWearSystem>(SystemUpdatePhase.PrefabUpdate);

            // Prefab scan: must work even while Options UI is open.
            updateSystem.UpdateAt<PrefabScanSystem>(SystemUpdatePhase.PrefabUpdate);

#if DEBUG
            // Debug probe: logs LaneCondition.m_Wear deltas/runtime lane wear info.
            updateSystem.UpdateAt<LaneWearProbeSystem>(SystemUpdatePhase.GameSimulation);
#endif

        }

        public void OnDispose()
        {
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
