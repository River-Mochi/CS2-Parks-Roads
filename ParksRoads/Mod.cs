// <copyright file="Mod.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Mod.cs
// Entrypoint: registers settings, locales, and ECS systems.

namespace ParksRoads
{
    using System;                    // Exception
    using System.Reflection;         // Assembly
    using Colossal.IO.AssetDatabase; // AssetDatabase.LoadSettings
    using Colossal.Localization;     // LocalizationManager
    using Colossal.Logging;          // ILog
    using CS2Shared.RiverMochi;      // LogUtils, ShellOpen
    using Game;                      // UpdateSystem, SystemUpdatePhase
    using Game.Modding;              // IMod
    using Game.SceneFlow;            // GameManager

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

            // Locales need the same settings instance used by Options.
            PRLSettings setting = new(this);
            Settings = setting;

            try
            {
                LocalizationManager? localizationManager = GameManager.instance?.localizationManager;

                if (localizationManager == null)
                {
                    LogUtils.Warn(s_Log, () => $"{ModTag} LocalizationManager is null; locale sources were not registered.");
                }
                else
                {
                    localizationManager.AddSource("en-US", new LocaleEN(setting));
                    localizationManager.AddSource("fr-FR", new LocaleFR(setting));
                    localizationManager.AddSource("es-ES", new LocaleES(setting));
                    localizationManager.AddSource("de-DE", new LocaleDE(setting));
                    localizationManager.AddSource("it-IT", new LocaleIT(setting));
                    localizationManager.AddSource("ja-JP", new LocaleJA(setting));
                    localizationManager.AddSource("ko-KR", new LocaleKO(setting));
                    localizationManager.AddSource("pl-PL", new LocalePL(setting));
                    localizationManager.AddSource("pt-BR", new LocalePT_BR(setting));
                    localizationManager.AddSource("zh-HANS", new LocaleZH_CN(setting));
                    localizationManager.AddSource("zh-HANT", new LocaleZH_HANT(setting));

                    // These locales are not officially supported by the game,
                    // but work with alternate language mods.
                    localizationManager.AddSource("pt-PT", new LocalePT_PT(setting));
                    localizationManager.AddSource("tr-TR", new LocaleTR(setting));
                    localizationManager.AddSource("vi-VN", new LocaleVI(setting));
                    localizationManager.AddSource("nl-NL", new LocaleNL(setting));
                }
            }
            catch (Exception ex)
            {
                LogUtils.Warn(s_Log, () => $"{ModTag} Localization registration failed: {ex.GetType().Name}: {ex.Message}");
            }

            AssetDatabase.global.LoadSettings(ModId, setting, new PRLSettings(this));
            setting.RegisterInOptionsUI();

            updateSystem.UpdateAfter<MaintenanceSystem>(SystemUpdatePhase.PrefabUpdate);
            updateSystem.UpdateAfter<LaneWearSystem>(SystemUpdatePhase.PrefabUpdate);

            // Prefab scan must work while the Options UI is open.
            updateSystem.UpdateAt<PrefabScanSystem>(SystemUpdatePhase.PrefabUpdate);

#if DEBUG
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
    }
}
