using System.Collections.Generic;
using ModestTree;
using TMPro;
using UnityEngine;

namespace Aviator.Code.Core.UI.Gameplay
{
    public class HistoryBar : MonoBehaviour
    {
        private Queue<TextMeshProUGUI> _historyPoints;
        private Queue<TextMeshProUGUI> _activeHistoryPoints;
        private Gradient _historyPointGradient;

        public void Construct(Queue<TextMeshProUGUI> historyPoints, Gradient historyPointGradient)
        {
            _historyPoints = historyPoints;
            _historyPointGradient = historyPointGradient;
            _activeHistoryPoints = new Queue<TextMeshProUGUI>(historyPoints.Count);
        }
        
        public void ShowHistoryPoint(float multiplier)
        {
            TextMeshProUGUI historyPoint = GetNewHistoryPoint();
            historyPoint.text = $"x{multiplier:0.00}";
            historyPoint.color = _historyPointGradient.Evaluate(multiplier / 10);
            ActiveHistoryPoint(historyPoint.gameObject);
        }

        private TextMeshProUGUI GetNewHistoryPoint()
        {
            if (!_historyPoints.IsEmpty())
            {
                TextMeshProUGUI historyPoint = _historyPoints.Dequeue();
                _activeHistoryPoints.Enqueue(historyPoint);
                return historyPoint;
            }
            
            TextMeshProUGUI activePoint = _activeHistoryPoints.Dequeue();
            _activeHistoryPoints.Enqueue(activePoint);
            return activePoint;
        }

        private void ActiveHistoryPoint(GameObject historyPoint)
        {
            historyPoint.transform.SetAsFirstSibling();
            historyPoint.SetActive(true);
        }
    }
}