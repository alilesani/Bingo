using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }
    
    private TouchControlls _touchControlls;
    private Camera _mainCamera;

    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        _touchControlls = new TouchControlls();
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _touchControlls.Enable();
    }

    private void OnDisable()
    {
        _touchControlls.Disable();
    }

    private void Start()
    {
        _touchControlls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        _touchControlls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }


    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnStartTouch(Utils.ScreenToWorld(_mainCamera, _touchControlls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) OnEndTouch(Utils.ScreenToWorld(_mainCamera, _touchControlls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }

    public Vector2 PrimaryPosition()
    {
        return Utils.ScreenToWorld(_mainCamera, _touchControlls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
}
