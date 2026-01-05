using System;
using Cameras;
using Gameplay;
using Gameplay.Collectables;
using Gui.Popups;
using Gui.Screens.Views;
using Message;
using Message.Messages;
using R3;
using UnityEngine;
using VContainer;

namespace Gui.Screens.Controllers
{
    public class PlayScreenController : IScreenController
    {
        [Inject] private readonly IMessageBroker _messageBroker;
        [Inject] private readonly IScoreManager _scoreManager;
        [Inject] private readonly ICameraManager _cameraManager;
        private IDisposable _onCollectedItemSubscription;
        private PlayScreenView _view;
        public string ID => GuiScreenIds.PlayScreen;

        public void SetView(IScreenView view)
        {
            _view = view as PlayScreenView;
        }

        public void Initialize(IScreenManager screenManager)
        {
            _view.OnShow = RegisterListeners;
            _view.OnHide = OnHideScreen;
        }

        private void OnHideScreen()
        {
            _view.cherriesCountText.text = "x 0";
            _view.gemsCountText.text = "x 0";
            RemoveListeners();
        }

        private void RegisterListeners()
        {
            _onCollectedItemSubscription = _messageBroker.Receive<CollectedItemMessage>().Subscribe(message =>
            {
                MoveCollectable(message.Collectable);
            });
            _view.pauseButton.onClick.AddListener(OnPauseButtonClick);
        }

        private void RemoveListeners()
        {
            _onCollectedItemSubscription.Dispose();
            _view.pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        }

        private void OnPauseButtonClick()
        {
            _messageBroker.Publish(new ShowPopupMessage(PopupIds.PauseMenuPopup));
            _messageBroker.Publish(new PauseGameMessage(true));
        }

        private void MoveCollectable(CollectableItem collectable)
        {
            switch (collectable.itemType)
            {
                case CollectedItem.Cherry:
                    collectable.OnCollected(_cameraManager.GetMainCamera(),
                        _view.cherriesRectTransform.position, () =>
                        {
                            _scoreManager.IncreaseCherryCount();
                            _view.cherriesCountText.text = "x " + _scoreManager.GetCherryCount();
                        });
                    break;
                case CollectedItem.Gem:
                    collectable.OnCollected(_cameraManager.GetMainCamera(),
                        _view.gemsRectTransform.position, () =>
                        {
                            _scoreManager.IncreaseGemCount();
                            _view.gemsCountText.text = "x " + _scoreManager.GetGemCount();
                        });
                    break;
            }
        }
    }
}
