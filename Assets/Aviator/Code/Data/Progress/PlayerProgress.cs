using System;
using System.Collections.Generic;

namespace Aviator.Code.Data.Progress
{
    [Serializable]
    public class PlayerProgress
    {
        public List<StatisticsData> StatisticHistory;
        public Settings Settings;
        public double Balance;

        public PlayerProgress(double startBalance)
        {
            Balance = startBalance;
            Settings = new Settings();
            StatisticHistory = new List<StatisticsData>(25);
        }
    }
}