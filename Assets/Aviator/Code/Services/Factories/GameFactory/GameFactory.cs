using Aviator.Code.Core.MultiplierRunner;
using Aviator.Code.Core.Plane;
using Aviator.Code.Core.Timer;
using Aviator.Code.Core.UI;
using Aviator.Code.Services.EntityContainer;
using Aviator.Code.Services.Sound;
using Aviator.Code.Services.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Aviator.Code.Services.Factories.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private readonly IStaticData _staticData;
        private readonly IEntityContainer _entityContainer;
        private readonly ISoundService _soundService;
        private readonly ICoroutineRunner _coroutineRunner;

        public GameFactory(IStaticData staticData, IEntityContainer entityContainer, ISoundService soundService,
            ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _staticData = staticData;
            _entityContainer = entityContainer;
            _soundService = soundService;
        }

        public GameObject CreateField() => Object.Instantiate(_staticData.AviatorPrefabs.FieldPrefab);

        public FieldText CreateFieldText(Transform parent)
        {
            FieldText fieldText = Object.Instantiate(_staticData.AviatorPrefabs.FieldTextPrefab, parent);
            _entityContainer.RegisterEntity(fieldText);
            return fieldText;
        }

        public ITimer CreateTimer(FieldText fieldText)
        {
            ITimer timer = new Timer(fieldText, _coroutineRunner, _staticData.AviatorSettingsConfig.StartGameTimerDelay);
            _entityContainer.RegisterEntity(timer);
            return timer;
        }

        public IMultiplierRunner CreateMultiplierRunner(FieldText fieldText)
        {
            IMultiplierRunner multiplierRunner = new MultiplierRunner(fieldText, _staticData, _coroutineRunner,
                _staticData.AviatorSettingsConfig.HistoryPointMultiplierGradient);
            _entityContainer.RegisterEntity(multiplierRunner);
            return multiplierRunner;
        }

        public PlaneView CreatePlaneView(Transform parent)
        {
            PlaneView planeView = Object.Instantiate(_staticData.AviatorPrefabs.PlaneViewPrefab, parent);
            planeView.Construct(_soundService);
            _entityContainer.RegisterEntity(planeView);
            return planeView;
        }
    }
}