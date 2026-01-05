using Gui.Popups;
using Gui.Screens;
using Message;
using Message.Messages;
using R3;
using TMPro;
using UnityEngine;
using VContainer;

namespace Gui
{
    public class GuiManager : MonoBehaviour
    {
        [Inject] private readonly IScreenManager _screenManager;
        [Inject] private readonly IPopupManager _popupManager;
        [Inject] private readonly IMessageBroker _messageBroker;

        [SerializeField] private Transform screensContainer;
        [SerializeField] private Transform popupsContainer;
        
        [SerializeField] private GameObject screenBlocker;
        
        public void Initialize()
        {
            _screenManager.Initialize(screensContainer, screenBlocker);
            _popupManager.Initialize(popupsContainer, screenBlocker);
        }
    }
}
