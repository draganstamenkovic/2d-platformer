using System;
using Gui.Screens.Views;
using Message;
using Message.Messages;
using UnityEngine;
using VContainer;
using R3;

namespace Gui.Screens.Controllers
{
    public class LoadingScreenController : IScreenController
    {
        [Inject] private readonly IMessageBroker _messageBroker;
        private IScreenManager _screenManager;
        private LoadingScreenView _view;
        public string ID => GuiScreenIds.LoadingScreen;
        
        private IDisposable _loadingMessageSubscription;
        public void SetView(IScreenView view)
        {
            _view = view as LoadingScreenView;
        }

        public void Initialize(IScreenManager screenManager)
        {
            _screenManager = screenManager;
            _view.OnShown = RegisterEvents;
            _view.OnHidden = UnregisterEvents;
        }

        private void RegisterEvents()
        {
            _loadingMessageSubscription = _messageBroker.Receive<LoadingMessage>().Subscribe(message =>
            {
                _view.progressText.text = message.Text;
            });
        }
        private void UnregisterEvents()
        {
            _loadingMessageSubscription.Dispose();
        }
    }
}