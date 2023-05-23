using Aviator.Code.Core.UI.Settings;
using Aviator.Code.Core.UI.Statistics;
using Aviator.Code.Data.Progress;
using UnityEngine;

namespace Aviator.Code.Services.Factories.PersistentEntityFactory
{
    public interface IPersistentEntityFactory
    {
        SettingsView CreateSettings(Transform parent);
        StatisticsScreenView CreateStatisticsScreen(Transform parent);
        StatisticElementView CreateStatisticElementView(StatisticsData statisticsData, Transform parent);
    }
}