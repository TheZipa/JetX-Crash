using System;
using Aviator.Code.Services.PersistentProgress;
using Aviator.Code.Services.SaveLoad;
using Aviator.Code.Services.StaticData;

namespace Aviator.Code.Services.UserBalance
{
    public class UserBalance : IUserBalance
    {
        private readonly IPersistentProgress _persistentProgress;
        private readonly ISaveLoad _saveLoadService;
        private readonly double _startBalance;

        public UserBalance(IPersistentProgress persistentProgress, ISaveLoad saveLoadService, IStaticData staticData)
        {
            _persistentProgress = persistentProgress;
            _saveLoadService = saveLoadService;
            _startBalance = staticData.AviatorSettingsConfig.StartCoins;
        }

        public void Add(double balance)
        {
            _persistentProgress.Progress.Balance += Math.Round(balance, 2);
            _saveLoadService.SaveProgress();
        }

        public void Minus(double balance)
        {
            _persistentProgress.Progress.Balance -= Math.Round(balance, 2);
            _saveLoadService.SaveProgress();
        }

        public bool TryReset()
        {
            if (_persistentProgress.Progress.Balance > 0) return false;
            
            _persistentProgress.Progress.Balance = _startBalance;
            _saveLoadService.SaveProgress();
            return true;
        }
    }
}