using System;
using System.Collections;
using Aviator.Code.Core.UI;
using Aviator.Code.Services;
using Aviator.Code.Services.StaticData;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Aviator.Code.Core.MultiplierRunner
{
    public class MultiplierRunner : IMultiplierRunner
    {
        public event Action OnReached;

        private readonly FieldText _fieldText;
        private readonly IStaticData _staticData;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly Gradient _multiplierGradient;
        
        private float _multiplier;
        private float _stepSpeed;

        public MultiplierRunner(FieldText fieldText, IStaticData staticData,
            ICoroutineRunner coroutineRunner, Gradient multiplierGradient)
        {
            _fieldText = fieldText;
            _staticData = staticData;
            _coroutineRunner = coroutineRunner;
            _multiplierGradient = multiplierGradient;
        }

        public void RunToMultiplier()
        {
            _multiplier = 1.00f;
            _stepSpeed = 0.3f;
            UpdateFieldText();
            _coroutineRunner.StartCoroutine(Run(DefineRandomMultiplier()));
        }

        public float GetMultiplier() => (float)Math.Round(_multiplier, 2);

        private IEnumerator Run(float multiplier)
        {
            while (multiplier > _multiplier)
            {
                _multiplier += 0.01f;
                UpdateFieldText();
                yield return new WaitForSeconds(IncreaseStepSpeed());
            }
            OnReached?.Invoke();
        }
        
        private float DefineRandomMultiplier()
        {
            float[] multiplierSectors = _staticData.AviatorSettingsConfig.MultiplierSectors;
            int max = Random.Range(1, multiplierSectors.Length);
            return (float)Math.Round(Random.Range(multiplierSectors[max - 1], multiplierSectors[max]), 2);
        }

        private void UpdateFieldText()
        {
            _fieldText.SetText($"x{_multiplier:0.00}");
            _fieldText.SetColor(_multiplierGradient.Evaluate(_multiplier / 10));
        }

        private float IncreaseStepSpeed()
        {
            if (_stepSpeed <= 0.025f) return _stepSpeed;
            return _stepSpeed -= 0.01f;
        }
    }
}