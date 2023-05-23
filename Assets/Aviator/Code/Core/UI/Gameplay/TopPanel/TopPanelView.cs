using System;
using Aviator.Code.Core.UI.Settings;
using Aviator.Code.Data.Enums;
using Aviator.Code.Services.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace Aviator.Code.Core.UI.Gameplay.TopPanel
{
    public class TopPanelView : MonoBehaviour
    {
        public event Action OnStatisticsClick;
        public event Action OnExitClick;
        
        public HistoryBar HistoryBar;
        
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _statisticsButton;
        
        private SettingsView _settingsPanel;
        private ISoundService _soundService;

        public void Construct(ISoundService soundService, SettingsView settingsPanel)
        {
            _soundService = soundService;
            _settingsPanel = settingsPanel;
        }

        private void Start()
        {
            _settingsButton.onClick.AddListener(SwitchSettingsPanel);
            _exitButton.onClick.AddListener(SendExitButtonClick);
            _statisticsButton.onClick.AddListener(SendStatisticsClick);
        }

        private void OnDestroy()
        {
            _settingsButton.onClick.RemoveListener(SwitchSettingsPanel);
            _exitButton.onClick.RemoveListener(SendExitButtonClick);
            _statisticsButton.onClick.RemoveListener(SendStatisticsClick);
        }

        private void SwitchSettingsPanel()
        {
            _soundService.PlayEffectSound(SoundId.Click);
            _settingsPanel.gameObject.SetActive(!_settingsPanel.gameObject.activeSelf);
        }

        private void SendExitButtonClick()
        {
            _soundService.PlayEffectSound(SoundId.Click);
            OnExitClick?.Invoke();
        }

        private void SendStatisticsClick()
        {
            _soundService.PlayEffectSound(SoundId.Click);
            OnStatisticsClick?.Invoke();
        }
    }
}