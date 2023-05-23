using System;
using UnityEngine;
using UnityEngine.UI;

namespace Aviator.Code.Core.UI.Settings
{
    public class SoundSwitcher : MonoBehaviour
    {
        public event Action<bool> OnSoundSwitched;
        
        [SerializeField] private Sprite _soundEnabledSprite;
        [SerializeField] private Sprite _soundDisabledSprite;
        [SerializeField] private Button _soundButton;

        private bool _isActive;

        public void SetDefault(bool isSoundActive)
        {
            _isActive = isSoundActive;
            SetButtonView();
        }

        private void Awake() =>
            _soundButton.onClick.AddListener(SwitchSound);

        private void OnDestroy() =>
            _soundButton.onClick.RemoveListener(SwitchSound);

        private void SwitchSound()
        {
            _isActive = !_isActive;
            SetButtonView();
            OnSoundSwitched?.Invoke(_isActive);
        }

        private void SetButtonView() =>
            _soundButton.image.sprite = _isActive 
                ? _soundEnabledSprite 
                : _soundDisabledSprite;
    }
}