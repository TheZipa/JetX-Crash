using System;
using Aviator.Code.Services.PersistentProgress;

namespace Aviator.Code.Core.UI.Gameplay.BetPanel
{
    public class BetPanel : IDisposable
    {
        private readonly BetPanelView _betPanelView;
        private readonly IPersistentProgress _persistentProgress;
        private double _userBet;

        public BetPanel(BetPanelView betPanelView, IPersistentProgress persistentProgress)
        {
            _betPanelView = betPanelView;
            _persistentProgress = persistentProgress;
            _betPanelView.OnPlaceBetClick += DefineUserBet;
        }

        public double GetBet()
        {
            double bet = _userBet;
            _userBet = 0;
            return bet;
        }

        public void UpdateUserBalance() =>
            _betPanelView.SetBalanceText(_persistentProgress.Progress.Balance);

        public void Dispose() => _betPanelView.OnPlaceBetClick -= DefineUserBet;

        private void DefineUserBet()
        {
            double userBet = _betPanelView.GetUserBet();
            if (userBet <= 0 || userBet > _persistentProgress.Progress.Balance)
            {
                _userBet = 0;
                _betPanelView.ShowWrongBetView();
                return;
            }
            
            _userBet = userBet;
            _betPanelView.ShowUserBet(_userBet);
        }
    }
}