using UnityEngine;
using UnityEngine.UI;

namespace Gui.Screens.Views
{
    public class PlayScreenView : ScreenView
    {
        public Button pauseButton;
        public override void Initialize()
        {
            ID = GuiScreenIds.PlayScreen;
        }
    }
}
