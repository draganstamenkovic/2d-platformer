using Gameplay.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        private IPlayerController _playerController;
        
        private float _moveValue;
        private bool _isActive;

        private InputAction _moveAction;
        private InputAction _jumpAction;

        private bool _jumpPressed;
        private bool _jumpConsumed;
        public void Initialize(IPlayerController playerController)
        {
            _playerController = playerController;
            _moveAction = InputSystem.actions.FindAction("Move");
            _jumpAction = InputSystem.actions.FindAction("Jump");
        }

        public void SetActive(bool value)
        {
            if (value)
            {
                _jumpAction.started += OnJumpStarted;
                _jumpAction.canceled += OnJumpCanceled;
            }
            else
            {
                _jumpAction.started -= OnJumpStarted;
                _jumpAction.canceled -= OnJumpCanceled;
            }
            _isActive = value;
        }

        private void OnJumpCanceled(InputAction.CallbackContext obj)
        {
            _jumpPressed = false;
        }

        private void OnJumpStarted(InputAction.CallbackContext obj)
        {
            _jumpPressed = true;
            _jumpConsumed = false;
        }

        private void Update()
        {
            if (!_isActive) return;
            
            if(_moveAction.IsPressed())
                _moveValue = _moveAction.ReadValue<Vector2>().x;
            if(!_moveAction.IsPressed())
                _playerController.Idle();
        }

        private void FixedUpdate()
        {
            if (!_isActive) return;

            if(_moveAction.IsPressed())
                _playerController.Move(_moveValue);

            if (_jumpPressed && !_jumpConsumed)
            {
                _playerController.Jump();
                _jumpConsumed = true;
            }
        }
    }
}