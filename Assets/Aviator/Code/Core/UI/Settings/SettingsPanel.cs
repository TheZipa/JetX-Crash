using System;
using Aviator.Code.Services.PersistentProgress;
using Aviator.Code.Services.SaveLoad;
using Aviator.Code.Services.Sound;

namespace Aviator.Code.Core.UI.Settings
{
    public class SettingsPanel : IDisposable
    {
        private readonly SettingsView _view;
        private readonly ISoundService _soundService;
        private readonly IPersistentProgress _persistentProgress;
        private readonly ISaveLoad _saveLoad;

        public SettingsPanel(SettingsView view, ISoundService soundService,
            IPersistentProgress persistentProgress, ISaveLoad saveLoad)
        {
            _view = view;
            _soundService = soundService;
            _persistentProgress = persistentProgress;
            _saveLoad = saveLoad;

            SubscribeView();
        }
        
        public void Dispose()
        {
            _view.EffectSoundSettingsView.OnSwitch -= OnEffectSoundSwitch;
            _view.MusicSoundSettingsView.OnSwitch -= OnMusicSoundSwitch;
            _view.EffectSoundSettingsView.OnVolumeChanged -= OnEffectVolumeChanged;
            _view.MusicSoundSettingsView.OnVolumeChanged -= OnMusicVolumeChanged;
        }

        private void SubscribeView()
        {
            _view.EffectSoundSettingsView.OnSwitch += OnEffectSoundSwitch;
            _view.MusicSoundSettingsView.OnSwitch += OnMusicSoundSwitch;
            _view.EffectSoundSettingsView.OnVolumeChanged += OnEffectVolumeChanged;
            _view.MusicSoundSettingsView.OnVolumeChanged += OnMusicVolumeChanged;
        }

        private void OnEffectSoundSwitch(bool isActive)
        {
            _soundService.EffectsMuted = _persistentProgress.Progress.Settings.IsEffectsSoundActive = isActive;
            _saveLoad.SaveProgress();
        }

        private void OnMusicSoundSwitch(bool isActive)
        {
            _soundService.MusicMuted = _persistentProgress.Progress.Settings.IsMusicSoundActive = isActive;
            _saveLoad.SaveProgress();
        }

        private void OnEffectVolumeChanged(float volume)
        {
            _persistentProgress.Progress.Settings.EffectsVolume = volume;
            _soundService.SetEffectsVolume(volume);
            _saveLoad.SaveProgress();
        }

        private void OnMusicVolumeChanged(float volume)
        {
            _persistentProgress.Progress.Settings.MusicVolume = volume;
            _soundService.SetBackgroundMusicVolume(volume);
            _saveLoad.SaveProgress();
        }
    }
}