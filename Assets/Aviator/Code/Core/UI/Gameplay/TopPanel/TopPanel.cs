using System;
using Aviator.Code.Core.UI.Statistics;
using Aviator.Code.Infrastructure.StateMachine.States;
using Aviator.Code.Infrastructure.StateMachine.StateSwitcher;

namespace Aviator.Code.Core.UI.Gameplay.TopPanel
{
    public class TopPanel : IDisposable
    {
        private readonly TopPanelView _topPanelView;
        private readonly StatisticsScreenView _statisticsView;
        private readonly IStateSwitcher _stateSwitcher;

        public TopPanel(TopPanelView topPanelView, StatisticsScreenView statisticsView, IStateSwitcher stateSwitcher)
        {
            _topPanelView = topPanelView;
            _statisticsView = statisticsView;
            _stateSwitcher = stateSwitcher;

            _topPanelView.OnExitClick += ExitToMainMenu;
            _topPanelView.OnStatisticsClick += ShowStatisticScreen;
        }

        public void AddHistoryPoint(float multiplier) =>
            _topPanelView.HistoryBar.ShowHistoryPoint(multiplier);

        public void Dispose()
        {
            _topPanelView.OnExitClick -= ExitToMainMenu;
            _topPanelView.OnStatisticsClick -= ShowStatisticScreen;
        }

        private void ExitToMainMenu() => _stateSwitcher.SwitchTo<MenuState>();

        private void ShowStatisticScreen() => _statisticsView.Show();
    }
}