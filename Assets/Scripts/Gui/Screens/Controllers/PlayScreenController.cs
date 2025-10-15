using Gui.Screens.Views;
using Message;
using Message.Messages;
using UnityEngine;
using VContainer;

namespace Gui.Screens.Controllers
{
    public class PlayScreenController : IScreenController
    {
        [Inject] private readonly IMessageBroker _messageBroker;
        private PlayScreenView _view;
        private IScreenManager _screenManager;
        public string ID => GuiScreenIds.PlayScreen;

        public void SetView(IScreenView view)
        {
            _view = view as PlayScreenView;
        }

        public void Initialize(IScreenManager screenManager)
        {
           _screenManager = screenManager;
            _view.OnShow = () => 
            { 
                _messageBroker.Publish(new PlayGameMessage());
                RegisterListeners();
            };
            _view.OnHidden = RemoveListeners;
        }

        private void RegisterListeners()
        {
        }

        private void RemoveListeners()
        {
        }
    }
}
