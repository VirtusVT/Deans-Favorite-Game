using System;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : SingletonInput<InputManager>
{
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;

    public delegate void MouseClickEvent(Vector2 position);
    public event MouseClickEvent MClick;

    private PlayerInputScript playerInput;

    private void Awake()
    {
        playerInput = new PlayerInputScript();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        playerInput.Touch.SingleFinger.started += ctx => StartTouch(ctx);
        playerInput.Touch.SingleFinger.canceled += ctx => EndTouch(ctx);
        playerInput.Mouse.Click.performed += _ => MouseClick();
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null)
            OnStartTouch(playerInput.Touch.Position.ReadValue<Vector2>(), (float) context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
            OnEndTouch(playerInput.Touch.Position.ReadValue<Vector2>(), (float)context.time);
    }
    
    private void MouseClick()
    {
        if (MClick != null)
            MClick(playerInput.Mouse.Position.ReadValue<Vector2>());
    }
}
