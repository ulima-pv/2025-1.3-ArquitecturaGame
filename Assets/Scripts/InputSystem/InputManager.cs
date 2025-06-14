using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions m_InputActions;

    void Awake()
    {
        m_InputActions = new InputSystem_Actions();
        m_InputActions.Enable();
    }

    void OnEnable()
    {
        m_InputActions.Player.Move.performed += OnMovement;
        m_InputActions.Player.Move.canceled += OnMovementStop;
        m_InputActions.Player.QTEKey.performed += OnQTEKeyPressed;
    }

    private void OnQTEKeyPressed(InputAction.CallbackContext context)
    {
        EventBus.Raise(new QTEKeyEvent());
    }

    private void OnMovementStop(InputAction.CallbackContext context)
    {
        EventBus.Raise<MovementEvent>(new MovementEvent(Vector2.zero));
    }

    private void OnMovement(
        InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        EventBus.Raise<MovementEvent>(new MovementEvent(direction));
    }

    void OnDisable()
    {
        
    }

}
