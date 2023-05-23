using System.Collections;
using UnityEngine;

namespace Aviator.Code.Core.UI.Gameplay.BetPanel
{
    public class ResetBalanceView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        private const float FadeDelay = 1.5f;
        private const float FadeStepTime = 0.01f;

        public void Show() => StartCoroutine(FadeShowHide());

        private IEnumerator FadeShowHide()
        {
            while (_canvasGroup.alpha < 1f)
            {
                yield return new WaitForSeconds(FadeStepTime);
                _canvasGroup.alpha += 0.05f;
            }
            
            yield return new WaitForSeconds(FadeDelay);
            
            while (_canvasGroup.alpha > 0f)
            {
                yield return new WaitForSeconds(FadeStepTime);
                _canvasGroup.alpha -= 0.025f;
            }
        }
    }
}