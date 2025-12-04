using UnityEngine.UI;

namespace Gui.Popups.Views
{
    public class PauseMenuPopupView : PopupView
    {
        public Button continueButton;
        public Button quitButton;
        public override void Initialize()
        {
            base.Initialize();
            ID = PopupIds.PauseMenuPopup;
        }
    }
}
