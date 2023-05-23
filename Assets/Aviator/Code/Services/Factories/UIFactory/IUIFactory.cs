using Aviator.Code.Core.UI;
using Aviator.Code.Core.UI.Gameplay.BetPanel;
using Aviator.Code.Core.UI.Gameplay.TopPanel;
using Aviator.Code.Core.UI.MainMenu;
using UnityEngine;

namespace Aviator.Code.Services.Factories.UIFactory
{
    public interface IUIFactory
    {
        GameObject CreateRootCanvas();
        MainMenuView CreateMainMenu(Transform parent);
        TopPanelView CreateTopPanel(Transform parent);
        WinPopUp CreateWinPopUp(Transform parent);
        BetPanelView CreateBetPanelView(Transform parent);
    }
}