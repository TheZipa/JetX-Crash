using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Aviator.Code.Core.UI.Gameplay.BetPanel
{
    public class BetInputField : TMP_InputField
    {
        [SerializeField] private Sprite _wrongBetSprite;
        [SerializeField] private GameObject _wrongBetView;
        [SerializeField] private TextMeshProUGUI _betText;

        private Sprite _defaultSprite;

        protected override void Awake()
        {
            base.Awake();
            _defaultSprite = image.sprite;
        }

        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
            HideWrongBetView();
        }

        public void ShowUserBet(double bet)
        {
            _betText.text = $"{bet:0.00}";
            _betText.gameObject.SetActive(true);
        }

        public void HideUserBet() => _betText.gameObject.SetActive(false);
        
        public void ShowWrongBetView()
        {
            HideUserBet();
            _wrongBetView.SetActive(true);
            image.sprite = _wrongBetSprite;
        }

        private void HideWrongBetView()
        {
            _wrongBetView.SetActive(false);
            image.sprite = _defaultSprite;
        }
    }
}