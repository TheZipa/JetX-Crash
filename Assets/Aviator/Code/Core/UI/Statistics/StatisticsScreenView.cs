using Aviator.Code.Core.UI.Settings;
using Aviator.Code.Data.Enums;
using Aviator.Code.Services.Sound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aviator.Code.Core.UI.Statistics
{
    public class StatisticsScreenView : MonoBehaviour
    {
        public Transform ScrollContent;
        
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private TextMeshProUGUI _noStatisticText;

        private SettingsView _settingsPanel;
        private ISoundService _soundService;

        private void Awake()
        {
            _exitButton.onClick.AddListener(Close);
            _settingsButton.onClick.AddListener(SwitchSettingsPanel);
            gameObject.SetActive(false);
        }
        
        public void Construct(ISoundService soundService) => _soundService = soundService;
        
        public void SetSettingsPanel(SettingsView settingsPanel) =>
            _settingsPanel = settingsPanel;

        public void AddStatisticElement(StatisticElementView elementView)
        {
            DisableNoStatisticText();
            elementView.transform.SetParent(ScrollContent);
            elementView.transform.SetAsFirstSibling();
        }
        
        public void Show() => gameObject.SetActive(true);

        private void Close()
        {
            _soundService.PlayEffectSound(SoundId.Click);
            gameObject.SetActive(false);
        }

        private void DisableNoStatisticText() =>
            _noStatisticText.gameObject.SetActive(false);

        private void SwitchSettingsPanel()
        {
            _soundService.PlayEffectSound(SoundId.Click);
            _settingsPanel.gameObject.SetActive(!_settingsPanel.gameObject.activeSelf);
        }

        private void OnDestroy()
        {
            _exitButton.onClick.RemoveListener(Close);
            _settingsButton.onClick.RemoveListener(SwitchSettingsPanel);
        }
    }
}