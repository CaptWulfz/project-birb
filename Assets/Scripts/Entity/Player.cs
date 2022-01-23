using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    private const float SPEED = 5f;
    //private float xMov = 0;
    //private float yMov = 0;

    Controls controls;

    private void Start()
    {
        controls = new Controls();
        controls.Player.Enable();
    }

    private void Update()
    {
        Vector2 move = controls.Player.Movement.ReadValue<Vector2>();
        Debug.Log(string.Format("Move Value: {0}", move));
        this.MovePosition(move * SPEED);
    }
}
