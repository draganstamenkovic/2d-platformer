using UnityEngine.UI;

namespace Gui.Screens.Views
{
    public class MainMenuScreenView : ScreenView
    {
        public Button settingsButton;
        public Button playButton;
        public Button quitButton;
        public override void Initialize()
        {
            ID = GuiScreenIds.MainMenuScreen;
        }
    }
}