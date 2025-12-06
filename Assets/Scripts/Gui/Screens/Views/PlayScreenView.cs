using TMPro;
using UnityEngine.UI;

namespace Gui.Screens.Views
{
    public class PlayScreenView : ScreenView
    {
        public Button pauseButton;
        public TextMeshProUGUI gemsCountText;
        public TextMeshProUGUI cherriesCountText;
        public override void Initialize()
        {
            ID = GuiScreenIds.PlayScreen;
        }
    }
}
