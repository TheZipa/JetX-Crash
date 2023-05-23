using System.Collections.Generic;
using Aviator.Code.Core.UI;
using Aviator.Code.Core.UI.Gameplay.BetPanel;
using Aviator.Code.Core.UI.Gameplay.TopPanel;
using Aviator.Code.Core.UI.MainMenu;
using Aviator.Code.Core.UI.Settings;
using Aviator.Code.Core.UI.Statistics;
using Aviator.Code.Infrastructure.StateMachine.StateSwitcher;
using Aviator.Code.Services.EntityContainer;
using Aviator.Code.Services.PersistentProgress;
using Aviator.Code.Services.Sound;
using Aviator.Code.Services.StaticData;
using TMPro;
using UnityEngine;

namespace Aviator.Code.Services.Factories.UIFactory
{
    public class UIFactory : IUIFactory
    {
        private readonly IPersistentProgress _playerProgress;
        private readonly ISoundService _soundService;
        private readonly IStaticData _staticData;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly IEntityContainer _entityContainer;

        public UIFactory(IEntityContainer entityContainer, IStaticData staticData, 
            IStateSwitcher stateSwitcher, IPersistentProgress playerProgress, ISoundService soundService)
        {
            _entityContainer = entityContainer;
            _playerProgress = playerProgress;
            _soundService = soundService;
            _staticData = staticData;
            _stateSwitcher = stateSwitcher;
        }

        public GameObject CreateRootCanvas() => 
            Object.Instantiate(_staticData.AviatorPrefabs.RootCanvasPrefab);

        public TopPanelView CreateTopPanel(Transform parent)
        {
            TopPanelView topPanelView = Object.Instantiate(_staticData.AviatorPrefabs.TopPanelViewPrefab, parent);
            topPanelView.Construct(_soundService, _entityContainer.GetEntity<SettingsView>());
            topPanelView.HistoryBar.Construct(CreateHistoryPointTexts(topPanelView.HistoryBar.transform), 
                _staticData.AviatorSettingsConfig.HistoryPointMultiplierGradient);
            _entityContainer.RegisterEntity(new TopPanel(topPanelView, 
                _entityContainer.GetEntity<StatisticsScreenView>(), _stateSwitcher));
            return topPanelView;
        }

        public BetPanelView CreateBetPanelView(Transform parent)
        {
            BetPanelView betPanelView = Object.Instantiate(_staticData.AviatorPrefabs.BetPanelViewPrefab, parent);
            betPanelView.Construct(_soundService, _playerProgress.Progress.Balance);
            _entityContainer.RegisterEntity(betPanelView);
            _entityContainer.RegisterEntity(new BetPanel(betPanelView, _playerProgress));
            return betPanelView;
        }

        public WinPopUp CreateWinPopUp(Transform parent)
        {
            WinPopUp winPopUp = Object.Instantiate(_staticData.AviatorPrefabs.WinPopUpPrefab, parent);
            _entityContainer.RegisterEntity(winPopUp);
            return winPopUp;
        }

        public MainMenuView CreateMainMenu(Transform parent)
        {
            MainMenuView menuView = Object.Instantiate(_staticData.AviatorPrefabs.MainMenuViewPrefab, parent);
            menuView.Construct(_soundService);
            return menuView;
        }

        private Queue<TextMeshProUGUI> CreateHistoryPointTexts(Transform parent)
        {
            int historyBarLength = _staticData.AviatorSettingsConfig.HistoryBarLength;
            Queue<TextMeshProUGUI> historyPointTexts = new Queue<TextMeshProUGUI>(historyBarLength);

            for(int i = 0; i < historyBarLength; i++)
            {
                TextMeshProUGUI historyPointText = Object.Instantiate(_staticData.AviatorPrefabs.HistoryPointTextPrefab, parent);
                historyPointText.gameObject.SetActive(false);
                historyPointTexts.Enqueue(historyPointText);
            }
            
            return historyPointTexts;
        }
    }
}