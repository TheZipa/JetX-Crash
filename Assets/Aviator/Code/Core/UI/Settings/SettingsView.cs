using Aviator.Code.Data.Enums;
using Aviator.Code.Services.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace Aviator.Code.Core.UI.Settings
{
    public class SettingsView : MonoBehaviour
    {
        public SoundSettingsView EffectSoundSettingsView;
        public SoundSettingsView MusicSoundSettingsView;
        
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _backgroundCloseButton;

        private ISoundService _soundService;

        private void Awake()
        {
            _closeButton.onClick.AddListener(Close);
            _backgroundCloseButton.onClick.AddListener(Close);
            gameObject.SetActive(false);
        }

        public void Construct(Data.Progress.Settings userSettings, ISoundService soundService)
        {
            _soundService = soundService;
            EffectSoundSettingsView.Construct(soundService, userSettings.IsEffectsSoundActive, userSettings.EffectsVolume);
            MusicSoundSettingsView.Construct(soundService, userSettings.IsMusicSoundActive, userSettings.MusicVolume);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(Close);
            _backgroundCloseButton.onClick.RemoveListener(Close);
        }

        private void Close()
        {
            _soundService.PlayEffectSound(SoundId.Click);
            gameObject.SetActive(false);
        }
    }
}