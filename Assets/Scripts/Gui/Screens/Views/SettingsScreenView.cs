using UnityEngine.UI;

namespace Gui.Screens.Views
{
    public class SettingsScreenView : ScreenView
    {
        public Button backButton;
        public Toggle soundToggle;
        public Toggle musicToggle;
        public override void Initialize()
        {
            ID = GuiScreenIds.SettingsScreen;
        }
    }
}
