using System.Collections;
using Aviator.Code.Data.Enums;
using Aviator.Code.Services.Sound;
using UnityEngine;

namespace Aviator.Code.Core.Plane
{
    public class PlaneView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private TrailRenderer _trail;
        [SerializeField] private Animator _explodeAnimation;
        [SerializeField] private Animator _animator;

        private readonly int _resetHash = Animator.StringToHash("Reset");
        private ISoundService _soundService;

        public void Construct(ISoundService soundService) =>
            _soundService = soundService;

        public void StartFly()
        {
            _trail.enabled = true;
            _animator.enabled = true;
        }

        public void ResetView()
        {
            _animator.SetTrigger(_resetHash);
            _animator.Rebind();
            _trail.enabled = false;
            _trail.Clear();
            _explodeAnimation.gameObject.SetActive(false);
            _spriteRenderer.color = Color.white;
        }

        public void Explode()
        {
            _animator.enabled = false;
            PlayExplodeAnimation();
            StartCoroutine(FadeHide());
            _soundService.PlayEffectSound(SoundId.Explosion);
        }

        private void PlayExplodeAnimation()
        {
            _explodeAnimation.gameObject.SetActive(true);
            _explodeAnimation.Rebind();
        }

        private IEnumerator FadeHide()
        {
            Color spriteColor = _spriteRenderer.color;
            while (spriteColor.a > 0f)
            {
                spriteColor.a -= 0.05f;
                _spriteRenderer.color = spriteColor;
                yield return null;
            }
            _spriteRenderer.color = spriteColor;
        }
    }
}