using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerController controller;
    private InputSystem_Actions m_InputActions;

    void Awake()
    {
        m_InputActions = new InputSystem_Actions();
        m_InputActions.Enable();
    }

    void OnEnable()
    {
        m_InputActions.Player.Move.performed += OnMovement;
    }

    private void OnMovement(
        InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        controller.Move(direction.normalized);
    }

    void OnDisable()
    {
        
    }

}
