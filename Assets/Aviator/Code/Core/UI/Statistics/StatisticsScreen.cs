using System;
using System.Collections.Generic;
using Aviator.Code.Data.Progress;
using Aviator.Code.Services.Factories.PersistentEntityFactory;
using Aviator.Code.Services.PersistentProgress;
using Aviator.Code.Services.SaveLoad;

namespace Aviator.Code.Core.UI.Statistics
{
    public class StatisticsScreen
    {
        private readonly IPersistentEntityFactory _persistentEntityFactory;
        private readonly StatisticsScreenView _statisticsScreenView;
        private readonly IPersistentProgress _persistentProgress;
        private readonly ISaveLoad _saveLoad;
        private readonly int _maxHistoryCount;

        public StatisticsScreen(IPersistentEntityFactory persistentEntityFactory, StatisticsScreenView statisticsScreenView,
            IPersistentProgress persistentProgress, ISaveLoad saveLoad, int maxHistoryCount)
        {
            _persistentEntityFactory = persistentEntityFactory;
            _statisticsScreenView = statisticsScreenView;
            _persistentProgress = persistentProgress;
            _saveLoad = saveLoad;
            _maxHistoryCount = maxHistoryCount;
        }

        public void AddStatistic(double userBet, float multiplier, double cashOut)
        {
            StatisticsData statisticsData = new StatisticsData
            {
                Multiplier = multiplier,
                Date = DateTime.Today.ToShortDateString(),
                Bet = userBet,
                CashOut = cashOut
            };
            
            SaveNewStatisticData(statisticsData);
            AddStatisticView(statisticsData);
        }

        private void SaveNewStatisticData(StatisticsData statisticsData)
        {
            List<StatisticsData> statisticHistory = _persistentProgress.Progress.StatisticHistory;
            if (statisticHistory.Count == _maxHistoryCount)
                statisticHistory[0] = statisticsData;
            else
                statisticHistory.Add(statisticsData);
            _saveLoad.SaveProgress();
        }

        private void AddStatisticView(StatisticsData statisticsData)
        {
            StatisticElementView statisticElementView =
                _persistentEntityFactory.CreateStatisticElementView(statisticsData, _statisticsScreenView.ScrollContent);
            _statisticsScreenView.AddStatisticElement(statisticElementView);
        }
    }
}