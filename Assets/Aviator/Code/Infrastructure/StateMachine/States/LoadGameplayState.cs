using Aviator.Code.Core.UI;
using Aviator.Code.Infrastructure.StateMachine.StateSwitcher;
using Aviator.Code.Services.Factories.GameFactory;
using Aviator.Code.Services.Factories.UIFactory;
using Aviator.Code.Services.SceneLoader;
using UnityEngine;

namespace Aviator.Code.Infrastructure.StateMachine.States
{
    public class LoadGameplayState : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private readonly IUIFactory _uiFactory;
        private readonly IGameFactory _gameFactory;
        private readonly ISceneLoader _sceneLoader;

        private const string GameScene = "Game";

        public LoadGameplayState(IStateSwitcher stateSwitcher, IUIFactory uiFactory, 
            IGameFactory gameFactory, ISceneLoader sceneLoader)
        {
            _stateSwitcher = stateSwitcher;
            _uiFactory = uiFactory;
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter() => _sceneLoader.LoadScene(GameScene, CreateGame);
        
        public void Exit()
        {
        }

        private void CreateGame()
        {
            CreateGameUI();
            CreateGameplayComponents();
            _stateSwitcher.SwitchTo<BetState>();
        }

        private void CreateGameplayComponents()
        {
            Transform fieldRoot = _gameFactory.CreateField().transform;
            FieldText fieldText = _gameFactory.CreateFieldText(fieldRoot);
            _gameFactory.CreatePlaneView(fieldRoot);
            _gameFactory.CreateTimer(fieldText);
            _gameFactory.CreateMultiplierRunner(fieldText);
        }

        private void CreateGameUI()
        {
            Transform gameRoot = _uiFactory.CreateRootCanvas().transform;
            _uiFactory.CreateTopPanel(gameRoot);
            _uiFactory.CreateBetPanelView(gameRoot);
            _uiFactory.CreateWinPopUp(gameRoot);
        }
    }
}