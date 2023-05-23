using System;
using Aviator.Code.Data.Enums;
using Aviator.Code.Services.Sound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aviator.Code.Core.UI.Gameplay.BetPanel
{
    public class BetPanelView : MonoBehaviour
    {
        public event Action OnPlaceBetClick;
        public event Action OnCashOutClick;
        
        [SerializeField] private TextMeshProUGUI _balanceText;
        [SerializeField] private Button _placeBetButton;
        [Space(5)] 
        [SerializeField] private BetInputField _betInputField;
        [SerializeField] private Button _cashOutButton;
        [SerializeField] private ResetBalanceView _resetBalanceView;
        
        private ISoundService _soundService;

        private void Awake()
        {
            _placeBetButton.onClick.AddListener(SendPlaceBet);
            _cashOutButton.onClick.AddListener(SendCashOut);
            _betInputField.onEndEdit.AddListener(CorrectUserBetInput);
        }
        
        public void Construct(ISoundService soundService, double userBalance)
        {
            _soundService = soundService;
            SetBalanceText(userBalance);
        }

        public double GetUserBet()
        {
            Double.TryParse(_betInputField.text, out double userBet);
            return userBet;
        }

        public void SetBalanceText(double balance) =>
            _balanceText.text = $"{balance:0.00}";

        public void SetBetActive(bool isActive) =>
            _placeBetButton.interactable = _betInputField.interactable = isActive;

        public void SetCashOutActive(bool isActive) =>
            _cashOutButton.interactable = isActive;

        public void ShowResetBalanceView() => _resetBalanceView.Show();

        public void ShowWrongBetView() => _betInputField.ShowWrongBetView();

        public void ShowUserBet(double bet) => _betInputField.ShowUserBet(bet);

        public void HideUserBet() => _betInputField.HideUserBet();

        private void CorrectUserBetInput(string inputValue) =>
            _betInputField.text = Math.Round(GetUserBet(), 2).ToString();

        private void SendPlaceBet()
        {
            _soundService.PlayEffectSound(SoundId.Click);
            OnPlaceBetClick?.Invoke();
        }

        private void SendCashOut()
        {
            _soundService.PlayEffectSound(SoundId.Click);
            OnCashOutClick?.Invoke();
        }

        private void OnDestroy()
        {
            _placeBetButton.onClick.RemoveListener(SendPlaceBet);
            _cashOutButton.onClick.RemoveListener(SendCashOut);
            _betInputField.onValueChanged.RemoveListener(CorrectUserBetInput);
        }
    }
}