using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System;


[Serializable] 
public class MoveInputEvent : UnityEvent<float, float> {}

public class InputController : MonoBehaviour
{

    //Input Action Asset qui décrit les différentes actions que l'on peut faire et les lie à des touches
    Controls controls;

    public MoveInputEvent moveInputEvent;


    private void Awake() {
        this.controls = new Controls();

    }

    private void OnEnable() {
        Debug.Log("enable");
        this.controls.Gameplay.Enable();
        this.controls.Gameplay.Move.performed += OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        this.moveInputEvent.Invoke(moveInput.x, moveInput.y);
        Debug.Log("moving");
    }
}
