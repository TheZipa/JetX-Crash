using Aviator.Code.Core.UI.MainMenu;
using Aviator.Code.Core.UI.Settings;
using Aviator.Code.Core.UI.Statistics;
using Aviator.Code.Infrastructure.StateMachine.StateSwitcher;
using Aviator.Code.Services.EntityContainer;
using Aviator.Code.Services.Factories.UIFactory;
using Aviator.Code.Services.SceneLoader;
using UnityEngine;

namespace Aviator.Code.Infrastructure.StateMachine.States
{
    public class MenuState : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly IEntityContainer _entityContainer;

        private const string MenuScene = "Menu";

        private MainMenuView _mainMenuView;
        private StatisticsScreenView _statisticsScreen;

        public MenuState(IStateSwitcher stateSwitcher, ISceneLoader sceneLoader, IUIFactory uiFactory, IEntityContainer entityContainer)
        {
            _stateSwitcher = stateSwitcher;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _entityContainer = entityContainer;
        }

        public void Enter() => _sceneLoader.LoadScene(MenuScene, InitializeUIElements);

        public void Exit()
        {
            _mainMenuView.OnPlayButtonClick -= StartGameplay;
            _mainMenuView.OnStatisticButtonClick -= _statisticsScreen.Show;
        }

        private void InitializeUIElements()
        {
            Transform rootCanvas = _uiFactory.CreateRootCanvas().transform;
            _statisticsScreen = _entityContainer.GetEntity<StatisticsScreenView>();
            InitializeMainMenuView(rootCanvas);
        }

        private void InitializeMainMenuView(Transform rootCanvas)
        {
            _mainMenuView = _uiFactory.CreateMainMenu(rootCanvas);
            _mainMenuView.SetSettingsPanel(_entityContainer.GetEntity<SettingsView>());
            _mainMenuView.OnPlayButtonClick += StartGameplay;
            _mainMenuView.OnStatisticButtonClick += _statisticsScreen.Show;
        }

        private void StartGameplay() =>
            _stateSwitcher.SwitchTo<LoadGameplayState>();
    }
}