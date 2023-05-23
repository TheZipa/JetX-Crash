using TMPro;
using UnityEngine;

namespace Aviator.Code.Core.UI.Statistics
{
    public class StatisticElementView : MonoBehaviour
    {
        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _multiplierText;
        [SerializeField] private TextMeshProUGUI _timeText;
        [SerializeField] private TextMeshProUGUI _betText;
        [SerializeField] private TextMeshProUGUI _cashOutText;
        [Header("Colors")] 
        [SerializeField] private Color _winColor;
        [SerializeField] private Color _loseColor;

        public void Construct(float multiplier, string time, double bet, double cashOut)
        {
            _timeText.text = time;
            _betText.text = $"{bet:0.00}";
            _multiplierText.text = $"x{multiplier:0.00}";
            SetCashOutText(cashOut);
        }

        private void SetCashOutText(double cashOut)
        {
            _cashOutText.text = $"{cashOut:0.00}";
            _cashOutText.color = cashOut > 0 ? _winColor : _loseColor;
        }
    }
}