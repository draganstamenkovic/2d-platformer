using System;
using Cameras;
using DG.Tweening;
using Gameplay;
using Gameplay.Collectables;
using Gui.Popups;
using Gui.Screens.Views;
using Message;
using Message.Messages;
using R3;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

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
                SpawnCollectableImage(message.Collectable);
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

        private void SpawnCollectableImage(CollectableItem collectable)
        {
            var screenPos = _cameraManager.GetMainCamera().WorldToScreenPoint(collectable.Position);
            RectTransform itemToInstantiate;
            RectTransform parentRect;
            Vector2 targetLocalPos;
            CollectableType collectableType = collectable.itemType;
            collectable.OnCollected();
            if (collectableType == CollectableType.Cherry)
            {
                itemToInstantiate = _view.cherriesRectTransform;
                parentRect = _view.cherriesRectTransform.parent as RectTransform;
                targetLocalPos = parentRect.InverseTransformPoint(_view.cherriesRectTransform.position);
                _scoreManager.IncreaseCherryCount();
            }
            else
            {
                itemToInstantiate = _view.gemsRectTransform;
                parentRect = _view.gemsRectTransform.parent as RectTransform;
                targetLocalPos  = parentRect.InverseTransformPoint(_view.gemsRectTransform.position);
                _scoreManager.IncreaseGemCount();
            }

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parentRect,
                screenPos,
                null,
                out var localPoint
            );

            var itemInstance = Object.Instantiate(itemToInstantiate, parentRect);

            var itemRect = (RectTransform)itemInstance.transform;
            itemRect.anchoredPosition = localPoint;
            
            itemRect.DOAnchorPos(targetLocalPos, 0.5f)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    if(collectableType == CollectableType.Cherry)
                        _view.cherriesCountText.text = "x " + _scoreManager.GetCherryCount();
                    else
                        _view.gemsCountText.text = "x " + _scoreManager.GetGemCount();
                });
        }

    }
}
