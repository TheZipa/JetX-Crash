using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Aviator.Code.Core.UI
{
    public class WinPopUp : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _winText;
        
        private const float FadeDelay = 3.5f;

        private void Awake() => _canvasGroup.alpha = 0f;

        public void Show(double winBalance)
        {
            _winText.text = $"You win {winBalance:0.00}";
            StartCoroutine(FadeShowHide());
        }

        private IEnumerator FadeShowHide()
        {
            while (_canvasGroup.alpha < 1f)
            {
                yield return new WaitForSeconds(0.01f);
                _canvasGroup.alpha += 0.05f;
            }
            
            yield return new WaitForSeconds(FadeDelay);
            
            while (_canvasGroup.alpha > 0f)
            {
                yield return new WaitForSeconds(0.02f);
                _canvasGroup.alpha -= 0.01f;
            }
        }
    }
}