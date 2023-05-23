using Aviator.Code.Data.Progress;
using Aviator.Code.Infrastructure.StateMachine.StateSwitcher;
using Aviator.Code.Services.PersistentProgress;
using Aviator.Code.Services.SaveLoad;
using Aviator.Code.Services.Sound;
using Aviator.Code.Services.StaticData;

namespace Aviator.Code.Infrastructure.StateMachine.States
{
    public class LoadProgressState : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly IPersistentProgress _playerProgress;
        private readonly ISaveLoad _saveLoadService;
        private readonly IStaticData _staticDataService;
        private readonly ISoundService _soundService;

        public LoadProgressState(IStateSwitcher stateSwitcher, IPersistentProgress playerProgress,
            ISaveLoad saveLoadService, IStaticData staticDataService, ISoundService soundService)
        {
            _staticDataService = staticDataService;
            _soundService = soundService;
            _saveLoadService = saveLoadService;
            _playerProgress = playerProgress;
            _stateSwitcher = stateSwitcher;
        }
        
        public void Enter()
        {
            LoadProgressOrInitNew();
            InitializeSoundVolume();
            _stateSwitcher.SwitchTo<LoadPersistentEntityState>();
        }

        public void Exit()
        {
        }
        
        private void LoadProgressOrInitNew() =>
            _playerProgress.Progress = _saveLoadService.LoadProgress() ?? CreateNewProgress();

        private PlayerProgress CreateNewProgress() => new PlayerProgress(_staticDataService.AviatorSettingsConfig.StartCoins);
        
        private void InitializeSoundVolume()
        {
            _soundService.Construct(_staticDataService.SoundData, _playerProgress.Progress.Settings);
            _soundService.PlayBackgroundMusic();
        }
    }
}