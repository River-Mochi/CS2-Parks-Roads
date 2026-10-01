// <copyright file="PRLSettings.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Settings/PRLSettings.cs
// Purpose: Options UI + saved settings for Parks, Roads & Lane Wear.

namespace ParksRoads
{
    using System;                    // Exception
    using Colossal.IO.AssetDatabase; // FileLocation
    using Colossal.PSI.Environment;   // EnvPath
    using CS2Shared.RiverMochi;      // LogUtils
    using Game;                      // IsGame
    using Game.Modding;              // IMod, ModSetting
    using Game.SceneFlow;            // GameManager
    using Game.Settings;             // Settings UI attributes
    using Unity.Entities;            // World
    using UnityEngine;               // Application.OpenURL

    [FileLocation("ModsSettings/ParksRoads/ParksRoads")]
    [SettingsUITabOrder(ActionsTab, AboutTab)]
    [SettingsUIGroupOrder(
        ParkMaintenanceGroup,
        RoadMaintenanceGroup,
        LaneWearGroup,
        AboutInfoGroup,
        AboutLinksGroup,
        DebugGroup
    )]
    [SettingsUIShowGroupName(
        ParkMaintenanceGroup,
        RoadMaintenanceGroup,
        LaneWearGroup,
        AboutLinksGroup,
        DebugGroup
    )]
    public partial class PRLSettings : ModSetting
    {
        // Tab ids.
        public const string ActionsTab = "Actions";
        public const string AboutTab = "About";

        // Group ids.
        public const string ParkMaintenanceGroup = "ParkMaintenance";
        public const string RoadMaintenanceGroup = "RoadMaintenance";
        public const string LaneWearGroup = "LaneWear";

        public const string AboutInfoGroup = "AboutInfo";
        public const string AboutLinksGroup = "AboutLinks";
        public const string DebugGroup = "Debug";

        // -----------------------
        // Slider ranges
        // -----------------------

        internal const float kVanillaPercent = 100f;

        // Parks + Roads: display as percent (100%..500% = 1x..5x).
        public const float MaintenanceMinPercent = 100f;
        public const float MaintenanceMaxPercent = 500f;
        public const float MaintenanceStepPercent = 10f;

        // Road wear speed: percent (5%..500% = 0.05x..5x).
        public const float RoadWearMinPercent = 5f;
        public const float RoadWearMaxPercent = 500f;
        public const float RoadWearStepPercent = 5f;

        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";

        private const string UrlDiscord =
            "https://discord.gg/HTav7ARPs2";

        public PRLSettings(IMod mod)
            : base(mod)
        {
            // New install starts with defaults. LoadSettings overwrites when .coc exists.
            SetDefaults();
        }

        public override void SetDefaults()
        {
            SetDefaults_ParksRoads();

            EnableDebugLogging = false;
        }

        public override void Apply()
        {
            base.Apply();

            GameManager gm = GameManager.instance;
            if (gm == null || !gm.gameMode.IsGame())
            {
                return;
            }

            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null)
            {
                return;
            }

            // Settings changes re-run systems once.
            TryEnableOnce<MaintenanceSystem>(world, "MaintenanceSystem");
            TryEnableOnce<LaneWearSystem>(world, "LaneWearSystem");
        }

        private static void TryEnableOnce<T>(World world, string label) where T : GameSystemBase
        {
            try
            {
                T sys = world.GetExistingSystemManaged<T>();
                if (sys != null)
                {
                    sys.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                LogUtils.Warn(Mod.s_Log, () => $"{Mod.ModTag} Apply: failed enabling {label}: {ex.GetType().Name}: {ex.Message}");
            }
        }

        // ----------------
        // About tab
        // ----------------

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string ModNameDisplay => $"{Mod.ModName} {Mod.ModTag}";

        [SettingsUISection(AboutTab, AboutInfoGroup)]
        public string ModVersionDisplay => $"{Mod.ModVersion} {Mod.BuildDisplayName}";

        [SettingsUIButtonGroup(AboutLinksGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, AboutLinksGroup)]
        public bool OpenParadoxMods
        {
            set
            {
                if (!value) return;

                try
                {
                    Application.OpenURL(UrlParadox);
                }
                catch (Exception ex)
                {
                    LogUtils.Info(Mod.s_Log, () => $"{Mod.ModTag} OpenParadoxMods failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        [SettingsUIButtonGroup(AboutLinksGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, AboutLinksGroup)]
        public bool OpenDiscord
        {
            set
            {
                if (!value) return;

                try
                {
                    Application.OpenURL(UrlDiscord);
                }
                catch (Exception ex)
                {
                    LogUtils.Info(Mod.s_Log, () => $"{Mod.ModTag} OpenDiscord failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // ----------------
        // Status / debug
        // ----------------

        [SettingsUIButtonGroup(DebugGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, DebugGroup)]
        public bool RunPrefabScanButton
        {
            set
            {
                if (!value) return;

                GameManager gm = GameManager.instance;
                if (gm == null || !gm.gameMode.IsGame())
                {
                    PrefabScanState.MarkFailed(PrefabScanState.FailCode.NoCityLoaded, null);
                    return;
                }

                if (!PrefabScanState.RequestScan())
                {
                    LogUtils.Info(Mod.s_Log, () => $"{Mod.ModTag} Prefab scan already queued/running.");
                    return;
                }

                try
                {
                    World world = World.DefaultGameObjectInjectionWorld;
                    if (world != null)
                    {
                        PrefabScanSystem scan = world.GetOrCreateSystemManaged<PrefabScanSystem>();
                        scan.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    PrefabScanState.MarkFailed(PrefabScanState.FailCode.Exception, $"{ex.GetType().Name}: {ex.Message}");
                    LogUtils.Warn(Mod.s_Log, () => $"{Mod.ModTag} RunPrefabScanButton failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        [SettingsUISection(AboutTab, DebugGroup)]
        public string PrefabScanStatus => PrefabScanStatusText.Format(PrefabScanState.GetSnapshot());

        [SettingsUIButtonGroup(DebugGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, DebugGroup)]
        public bool OpenReportButton
        {
            set
            {
                if (value)
                {
                    string reportFolder = System.IO.Path.Combine(EnvPath.kUserDataPath, "ModsData", Mod.ModId);
                    ShellOpen.OpenFolder(reportFolder, "OpenReport");
                }
            }
        }

#if DEBUG
        [SettingsUISection(AboutTab, DebugGroup)]
        public bool EnableDebugLogging { get; set; }
#else
        [SettingsUIHidden]
        public bool EnableDebugLogging
        {
            get => false;
            set { }
        }
#endif

        [SettingsUIButtonGroup(DebugGroup)]
        [SettingsUIButton]
        [SettingsUISection(AboutTab, DebugGroup)]
        public bool OpenLogButton
        {
            set
            {
                if (value)
                {
                    ShellOpen.OpenModLogOrLogsFolder();
                }
            }
        }

        // Partial hooks keep files organized without duplicating boilerplate.
        partial void SetDefaults_ParksRoads();
    }
}
