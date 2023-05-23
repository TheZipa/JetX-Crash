using Aviator.Code.Core.Plane;
using Aviator.Code.Core.UI;
using Aviator.Code.Core.UI.Gameplay.BetPanel;
using Aviator.Code.Core.UI.Gameplay.TopPanel;
using Aviator.Code.Core.UI.MainMenu;
using Aviator.Code.Core.UI.Settings;
using Aviator.Code.Core.UI.Statistics;
using TMPro;
using UnityEngine;

namespace Aviator.Code.Data.StaticData
{
    [CreateAssetMenu(fileName = "Aviator Prefabs", menuName = "Static Data/Aviator Prefabs")]
    public class AviatorPrefabs : ScriptableObject
    {
        public GameObject RootCanvasPrefab;
        [Header("Settings")]
        public SettingsView SettingsViewPrefab;
        public SoundSwitcher SoundSwitcherPrefab;
        [Header("Main Menu")]
        public MainMenuView MainMenuViewPrefab;
        [Header("Gameplay UI")]
        public TopPanelView TopPanelViewPrefab;
        public TextMeshProUGUI HistoryPointTextPrefab;
        public BetPanelView BetPanelViewPrefab;
        public WinPopUp WinPopUpPrefab;
        [Header("Gameplay Views")] 
        public PlaneView PlaneViewPrefab;
        public GameObject FieldPrefab;
        public FieldText FieldTextPrefab;
        [Header("Statistics")] 
        public StatisticsScreenView StatisticsScreenViewPrefab;
        public StatisticElementView StatisticElementViewPrefab;
    }
}