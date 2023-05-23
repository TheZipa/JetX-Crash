using System;
using Aviator.Code.Data.Enums;
using Aviator.Code.Services.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace Aviator.Code.Core.UI.Settings
{
    public class SoundSettingsView : MonoBehaviour
    {
        public event Action<bool> OnSwitch;
        public event Action<float> OnVolumeChanged;
        
        [SerializeField] private SoundSwitcher _soundSwitcher;
        [SerializeField] private Slider _volumeSlider;

        private ISoundService _soundService;
        
        private void Awake()
        {
            _soundSwitcher.OnSoundSwitched += OnSoundSwitch;
            _volumeSlider.onValueChanged.AddListener(SendVolumeChange);
        }

        public void Construct(ISoundService soundService, bool isActive, float volume)
        {
            _soundService = soundService;
            _soundSwitcher.SetDefault(isActive);
            _volumeSlider.interactable = isActive;
            _volumeSlider.value = volume;
        }

        private void OnSoundSwitch(bool isActive)
        {
            _volumeSlider.interactable = isActive;
            _soundService.PlayEffectSound(SoundId.Click);
            OnSwitch?.Invoke(isActive);
        }

        private void SendVolumeChange(float volume) =>
            OnVolumeChanged?.Invoke(volume);

        private void OnDestroy()
        {
            _soundSwitcher.OnSoundSwitched -= OnSoundSwitch;
            _volumeSlider.onValueChanged.RemoveListener(SendVolumeChange);
        }
    }
}