using UnityEngine.UI;

namespace Gui.Screens.Views
{
    public class SettingsScreenView : ScreenView
    {
        public Button backButton;
        public override void Initialize()
        {
            ID = GuiScreenIds.SettingsScreen;
        }
    }
}
