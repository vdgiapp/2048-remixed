using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Remixed2048.Input
{
    public class InputManager : MonoSingleton<InputManager>
    {
        public event Action<Vector2> OnPlayerSwipe;
        
        [SerializeField]
        private float minimumSwipeMagnitude = 15f;
        
        private Vector2 _swipeDirection;
        private PlayerControls _playerControls;

        private void Start()
        {
            _playerControls = new PlayerControls();
            _playerControls.Main.Enable();
            ConnectSignals();
        }
        
        private void OnDestroy()
        {
            DisconnectSignals();
        }

        private void ConnectSignals()
        {
            var main = _playerControls.Main;
            main.Touch.canceled += OnTouchCanceled;
            main.Swipe.performed += OnSwipePerformed;
            main.Up.performed += OnKeyboardUp;
            main.Down.performed += OnKeyboardDown;
            main.Left.performed += OnKeyboardLeft;
            main.Right.performed += OnKeyboardRight;
        }

        private void DisconnectSignals()
        {
            var main = _playerControls.Main;
            main.Touch.canceled -= OnTouchCanceled;
            main.Swipe.performed -= OnSwipePerformed;
            main.Up.performed -= OnKeyboardUp;
            main.Down.performed -= OnKeyboardDown;
            main.Left.performed -= OnKeyboardLeft;
            main.Right.performed -= OnKeyboardRight;
        }

        private void OnSwipePerformed(InputAction.CallbackContext context)
        {
            _swipeDirection = context.ReadValue<Vector2>();
        }

        private void OnTouchCanceled(InputAction.CallbackContext context)
        {
            float magnitude = Mathf.Abs(_swipeDirection.magnitude);
            if (magnitude < minimumSwipeMagnitude) return;
 
            // Determine dominant axis
            Vector2 dir = _swipeDirection.normalized;
            OnPlayerSwipe?.Invoke(dir * magnitude);
        }
        
        private void OnKeyboardUp(InputAction.CallbackContext context) =>
            OnPlayerSwipe?.Invoke(new Vector2(0, 1));

        private void OnKeyboardDown(InputAction.CallbackContext context) =>
            OnPlayerSwipe?.Invoke(new Vector2(0, -1));

        private void OnKeyboardLeft(InputAction.CallbackContext context) =>
            OnPlayerSwipe?.Invoke(new Vector2(-1, 0));

        private void OnKeyboardRight(InputAction.CallbackContext context) =>
            OnPlayerSwipe?.Invoke(new Vector2(1, 0));
    }
}