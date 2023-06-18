using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour {

    public static GameInput Instance { get; private set; }

    public event EventHandler OnJumpPressed;

    private InputActions inputActions;
    private void Awake() {
        Instance = this;
        inputActions = new InputActions();
        inputActions.Player.Enable();

        inputActions.Player.Jump.performed += Jump_performed;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnJumpPressed?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized() {
        return inputActions.Player.Move.ReadValue<Vector2>();
    }
}
