using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Remixed2048.Input
{
    public class InputManager : MonoSingleton<InputManager>
    {
        public event Action<SwipeDirection> swiped;
        
        [SerializeField]
        private float minimumSwipeMagnitude = 15f;
        
        private Vector2 _swipeDirection = Vector2.zero;
        
        // Player controls
        private PlayerControls _playerControls;
        private PlayerControls.MainActions _mainActions;

        protected override void Awake()
        {
            base.Awake();
            _playerControls = new PlayerControls();
            _mainActions = _playerControls.Main;
            _mainActions.Enable();
            ConnectSignals();
        }
        
        protected override void OnDestroy()
        {
            DisconnectSignals();
            base.OnDestroy();
        }

        private void ConnectSignals()
        {
            _mainActions.Swipe.performed += OnSwipePerformed;
            _mainActions.Touch.canceled += OnTouchCanceled;
            _mainActions.Up.performed += OnKeyboardUp;
            _mainActions.Down.performed += OnKeyboardDown;
            _mainActions.Left.performed += OnKeyboardLeft;
            _mainActions.Right.performed += OnKeyboardRight;
        }

        private void DisconnectSignals()
        {
            _mainActions.Swipe.performed -= OnSwipePerformed;
            _mainActions.Touch.canceled -= OnTouchCanceled;
            _mainActions.Up.performed -= OnKeyboardUp;
            _mainActions.Down.performed -= OnKeyboardDown;
            _mainActions.Left.performed -= OnKeyboardLeft;
            _mainActions.Right.performed -= OnKeyboardRight;
        }

        private void OnSwipePerformed(InputAction.CallbackContext context)
        {
            _swipeDirection = context.ReadValue<Vector2>();
        }

        private void OnTouchCanceled(InputAction.CallbackContext context)
        {
            float magnitude = _swipeDirection.magnitude;
            if (magnitude < minimumSwipeMagnitude) return;
 
            Vector2 dir = _swipeDirection.normalized;
            SwipeDirection swipeDir;

            if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
                swipeDir = dir.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
            else
                swipeDir = dir.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;

            swiped?.Invoke(swipeDir);
        }
        
        private void OnKeyboardUp(InputAction.CallbackContext context) =>
            swiped?.Invoke(SwipeDirection.Up);

        private void OnKeyboardDown(InputAction.CallbackContext context) =>
            swiped?.Invoke(SwipeDirection.Down);

        private void OnKeyboardLeft(InputAction.CallbackContext context) =>
            swiped?.Invoke(SwipeDirection.Left);

        private void OnKeyboardRight(InputAction.CallbackContext context) =>
            swiped?.Invoke(SwipeDirection.Right);
    }
}