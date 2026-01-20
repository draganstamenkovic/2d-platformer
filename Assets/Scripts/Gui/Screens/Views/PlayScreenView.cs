using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gui.Screens.Views
{
    public class PlayScreenView : ScreenView
    {
        public RectTransform screenRectTransform;
        public Button pauseButton;
        public TextMeshProUGUI gemsCountText;
        public TextMeshProUGUI cherriesCountText;
        public RectTransform gemsRectTransform;
        public RectTransform cherriesRectTransform;
        public override void Initialize()
        {
            ID = GuiScreenIds.PlayScreen;
        }
    }
}
