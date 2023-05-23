using Aviator.Code.Infrastructure.StateMachine.GameStateMachine;
using Aviator.Code.Infrastructure.StateMachine.States;
using Aviator.Code.Infrastructure.StateMachine.StateSwitcher;
using Aviator.Code.Services.StateFactory;
using Zenject;

namespace Aviator.Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            RegisterBootstrapInstaller();
            RegisterStateSwitcher();
            RegisterStateFactory();
            RegisterStateMachine();
        }
        
        public void Initialize() =>
            Container
                .Resolve<IStateSwitcher>()
                .SwitchTo<LoadProgressState>();

        private void RegisterBootstrapInstaller() =>
            Container
                .BindInterfacesTo<BootstrapInstaller>()
                .FromInstance(this)
                .AsSingle();

        private void RegisterStateMachine() =>
            Container
                .BindInterfacesTo<GameStateMachine>()
                .AsSingle()
                .NonLazy();
        
        private void RegisterStateSwitcher() =>
            Container
                .Bind<IStateSwitcher>()
                .To<StateSwitcher>()
                .AsSingle()
                .NonLazy();
        
        private void RegisterStateFactory() =>
            Container
                .Bind<IStateFactory>()
                .To<StatesFactory>()
                .AsSingle()
                .NonLazy();
    }
}