// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// This notice MUST be kept with copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocalePT_BR.cs
// Portuguese-Brazil (pt-BR) strings for Options UI.

namespace ParksRoads
{
    using System.Collections.Generic;
    using Colossal;

    public class LocalePT_BR : IDictionarySource
    {
        private readonly PRLSettings m_Setting;

        public LocalePT_BR(PRLSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(PRLSettings.ActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(PRLSettings.AboutTab), "Sobre" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.ParkMaintenanceGroup), "Manutenção de parques" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.RoadMaintenanceGroup), "Reparo de vias" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.LaneWearGroup), "Desgaste das faixas" },

                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutInfoGroup), "Informações" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.AboutLinksGroup), "Links de suporte" },
                { m_Setting.GetOptionGroupLocaleID(PRLSettings.DebugGroup), "Relatório de status / depuração" },

                // -------------------
                // Park maintenance
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)), "Tamanho da frota do depósito" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceDepotScalar)),
                    "Ajusta o **máximo de veículos** do depósito de manutenção de parques.\n" +
                    "**100%** = padrão do jogo." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)), "Capacidade de trabalho" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleCapacityScalar)),
                    "Ajusta a **capacidade de trabalho** da manutenção de parques.\n" +
                    "É o trabalho total que um veículo pode fazer antes de voltar ao prédio.\n" +
                    "**100%** = padrão do jogo." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)), "Ritmo de trabalho" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ParkMaintenanceVehicleRateScalar)),
                    "Ajusta a velocidade de trabalho dos veículos de manutenção de parques.\n" +
                    "**100%** = padrão do jogo." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Redefinir manutenção de parques" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetParkMaintenanceToVanillaButton)), "Redefine os valores de manutenção de parques para **100%**." },

                // -------------------
                // Road repair
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)), "Tamanho da frota do depósito" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceDepotScalar)),
                    "Ajusta o **máximo de veículos** do depósito de manutenção viária.\n" +
                    "Valores maiores permitem mais veículos de manutenção viária.\n" +
                    "**100%** = padrão do jogo." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)), "Capacidade de trabalho" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleCapacityScalar)),
                    "Ajusta a **capacidade de trabalho** da manutenção viária.\n" +
                    "Valores maiores permitem fazer mais reparos antes de voltar ao depósito.\n" +
                    "**100%** = padrão do jogo." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)), "Ritmo de reparo" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadMaintenanceVehicleRateScalar)),
                    "Ajusta a velocidade com que os veículos de manutenção reparam as vias.\n" +
                    "**100%** = padrão do jogo." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Redefinir reparo de vias" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetRoadMaintenanceToVanillaButton)), "Redefine frota do depósito, capacidade de trabalho e ritmo de reparo para **100%**." },

                // -------------------
                // Lane wear
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RoadWearScalar)), "Desgaste das faixas / danos nas vias" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RoadWearScalar)),
                    "Controla a velocidade de deterioração das vias por **tempo e tráfego**.\n" +
                    "**5%** = desgaste muito mais lento.\n" +
                    "**100%** = padrão do jogo.\n" +
                    "**500%** = desgaste mais rápido.\n" +
                    "Altera os dados de deterioração das faixas usados para desgaste / danos nas vias." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Redefinir desgaste das faixas" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ResetLaneWearToVanillaButton)), "Redefine o desgaste das faixas para **100%** sem alterar os ajustes de reparo." },

                // -------------------
                // About / debug
                // -------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModNameDisplay)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModNameDisplay)), "Nome exibido deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.ModVersionDisplay)), "Versão atual do mod e tipo de build." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Mods da Mochi no Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenParadoxMods)), "Abre a página de mods da River-mochi no Paradox." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenDiscord)), "Abre o Discord da comunidade no navegador." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.RunPrefabScanButton)), "Relatório de verificação" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.RunPrefabScanButton)),
                    "Cria um relatório único para parques, reparo de vias e desgaste das faixas.\n" +
                    "Não é necessário para jogar normalmente.\n" +
                    "Local do arquivo: <ModsData/ParksRoads/ScanReport-ParksRoads.txt>\n" +
                    "Clique uma vez, espere o status mostrar Concluído e use <Abrir pasta do relatório>." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.PrefabScanStatus)), "Status do relatório" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.PrefabScanStatus)),
                    "Mostra o estado: Inativo / Na fila / Executando / Concluído / Falhou.\n" +
                    "Concluído mostra a duração e o horário de conclusão." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.EnableDebugLogging)), "Logs de depuração detalhados" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.EnableDebugLogging)),
                    "Grava detalhes extras em <ParksRoads.log> para solucionar problemas.\n" +
                    "Desative durante o jogo normal." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenLogButton)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenLogButton)),
                    "Abre <Logs/ParksRoads.log> ou a pasta Logs se o arquivo ainda não existir.\n" +
                    "Você pode usar o Notepad++ para ver os arquivos de log." },

                { m_Setting.GetOptionLabelLocaleID(nameof(PRLSettings.OpenReportButton)), "Abrir pasta do relatório" },
                { m_Setting.GetOptionDescLocaleID(nameof(PRLSettings.OpenReportButton)),
                    "Abre a pasta do relatório.\n" +
                    "Depois abra <ScanReport-ParksRoads.txt> no seu editor de texto." },

                // ---- Scan Report Status Text ----
                { "PRL_SCAN_IDLE", "Inativo" },
                { "PRL_SCAN_QUEUED_FMT", "Na fila ({0})" },
                { "PRL_SCAN_RUNNING_FMT", "Executando ({0})" },
                { "PRL_SCAN_DONE_FMT", "Concluído ({0} | {1})" },
                { "PRL_SCAN_FAILED", "Falhou" },
                { "PRL_SCAN_FAIL_NO_CITY", "Carregue uma cidade primeiro" },
                { "PRL_SCAN_UNKNOWN_TIME", "horário desconhecido" },
            };
        }

        public void Unload()
        {
        }
    }
}
