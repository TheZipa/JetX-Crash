using System.Collections.Generic;
using Aviator.Code.Core.UI.Settings;
using Aviator.Code.Core.UI.Statistics;
using Aviator.Code.Data.Progress;
using Aviator.Code.Services.EntityContainer;
using Aviator.Code.Services.PersistentProgress;
using Aviator.Code.Services.SaveLoad;
using Aviator.Code.Services.Sound;
using Aviator.Code.Services.StaticData;
using UnityEngine;

namespace Aviator.Code.Services.Factories.PersistentEntityFactory
{
    public class PersistentEntityFactory : IPersistentEntityFactory
    {
        private readonly IEntityContainer _entityContainer;
        private readonly IPersistentProgress _persistentProgress;
        private readonly ISaveLoad _saveLoad;
        private readonly ISoundService _soundService;
        private readonly IStaticData _staticData;

        public PersistentEntityFactory(IEntityContainer entityContainer, IStaticData staticData, 
            IPersistentProgress persistentProgress, ISaveLoad saveLoad, ISoundService soundService)
        {
            _entityContainer = entityContainer;
            _persistentProgress = persistentProgress;
            _saveLoad = saveLoad;
            _soundService = soundService;
            _staticData = staticData;
        }
        
        public SettingsView CreateSettings(Transform parent)
        {
            SettingsView settingsView = Object.Instantiate(_staticData.AviatorPrefabs.SettingsViewPrefab, parent);
            settingsView.Construct(_persistentProgress.Progress.Settings, _soundService);
            _entityContainer.RegisterEntity(new SettingsPanel(settingsView, _soundService, _persistentProgress, _saveLoad));
            _entityContainer.RegisterEntity(settingsView);
            return settingsView;
        }

        public StatisticsScreenView CreateStatisticsScreen(Transform parent)
        {
            StatisticsScreenView statisticsScreenView = CreateStatisticsScreenView(parent);

            _entityContainer.RegisterEntity(new StatisticsScreen(this, statisticsScreenView,
                _persistentProgress, _saveLoad, _staticData.AviatorSettingsConfig.MaxHistoryCount));
            _entityContainer.RegisterEntity(statisticsScreenView);
            
            return statisticsScreenView;
        }

        public StatisticElementView CreateStatisticElementView(StatisticsData statisticsData, Transform parent)
        {
            StatisticElementView elementView =
                Object.Instantiate(_staticData.AviatorPrefabs.StatisticElementViewPrefab, parent);
            elementView.Construct(statisticsData.Multiplier, statisticsData.Date, statisticsData.Bet, statisticsData.CashOut);
            return elementView;
        }

        private StatisticsScreenView CreateStatisticsScreenView(Transform parent)
        {
            StatisticsScreenView statisticsScreenView =
                Object.Instantiate(_staticData.AviatorPrefabs.StatisticsScreenViewPrefab, parent);
            CreateStatisticElementViews(statisticsScreenView);

            statisticsScreenView.Construct(_soundService);
            return statisticsScreenView;
        }

        private void CreateStatisticElementViews(StatisticsScreenView statisticsScreenView)
        {
            List<StatisticsData> statisticHistory = _persistentProgress.Progress.StatisticHistory;

            foreach (StatisticsData statisticData in statisticHistory)
            {
                StatisticElementView elementView =
                    CreateStatisticElementView(statisticData, statisticsScreenView.ScrollContent);
                statisticsScreenView.AddStatisticElement(elementView);
            }
        }
    }
}