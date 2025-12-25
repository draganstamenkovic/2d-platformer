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
        
        [SerializeField] private Transform loadingScreen;
        [SerializeField] private TextMeshProUGUI loadingText;
        [SerializeField] private GameObject screenBlocker;
        
        public void Initialize()
        {
            loadingScreen.gameObject.SetActive(true);
            _screenManager.Initialize(screensContainer, screenBlocker);
            _popupManager.Initialize(popupsContainer, screenBlocker);

            _messageBroker.Receive<LoadingMessage>().Subscribe(message =>
            {
                loadingText.text = message.Text;
                loadingScreen.gameObject.SetActive(message.Active);
            });
        }
    }
}
