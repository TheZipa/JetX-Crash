using Aviator.Code.Services;
using Aviator.Code.Services.EntityContainer;
using Aviator.Code.Services.Factories.GameFactory;
using Aviator.Code.Services.Factories.PersistentEntityFactory;
using Aviator.Code.Services.Factories.UIFactory;
using Aviator.Code.Services.PersistentProgress;
using Aviator.Code.Services.SaveLoad;
using Aviator.Code.Services.SceneLoader;
using Aviator.Code.Services.Sound;
using Aviator.Code.Services.StaticData;
using Aviator.Code.Services.StaticData.StaticDataProvider;
using Aviator.Code.Services.UserBalance;
using UnityEngine;
using Zenject;

namespace Aviator.Code.Infrastructure.Installers
{
    public class ServiceInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private SoundService _soundService;
        
        public override void InstallBindings()
        {
            RegisterSceneLoader();
            RegisterStaticDataProvider();
            RegisterCoroutineRunner();
            RegisterEntityContainer();
            RegisterSaveLoad();
            RegisterPersistentProgress();
            RegisterStaticData();
            RegisterUserBalance();
            RegisterSoundService();
            RegisterPersistentEntityFactory();
            RegisterUIFactory();
            RegisterGameFactory();
        }

        private void RegisterSceneLoader() =>
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();

        private void RegisterStaticDataProvider() =>
            Container.Bind<IStaticDataProvider>().To<StaticDataProvider>().AsSingle();

        private void RegisterCoroutineRunner() =>
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();

        private void RegisterEntityContainer() =>
            Container.BindInterfacesTo<EntityContainer>().AsSingle();

        private void RegisterSaveLoad() =>
            Container.Bind<ISaveLoad>().To<PrefsSaveLoad>().AsSingle();

        private void RegisterPersistentProgress() =>
            Container.Bind<IPersistentProgress>().To<PersistentPlayerProgress>().AsSingle();

        private void RegisterStaticData() =>
            Container.Bind<IStaticData>().To<StaticData>().AsSingle();

        private void RegisterUserBalance() =>
            Container.Bind<IUserBalance>().To<UserBalance>().AsSingle();

        private void RegisterSoundService() =>
            Container.Bind<ISoundService>().FromInstance(_soundService).AsSingle();

        private void RegisterPersistentEntityFactory() =>
            Container.Bind<IPersistentEntityFactory>().To<PersistentEntityFactory>().AsSingle();

        private void RegisterUIFactory() =>
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();

        private void RegisterGameFactory() =>
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
    }
}