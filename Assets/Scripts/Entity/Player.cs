using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private float xMov = 0;
    private float yMov = 0;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            this.xMov = -5;
        if (Input.GetKey(KeyCode.D))
            this.xMov = 5;
        if (Input.GetKey(KeyCode.W))
            this.yMov = 5;
        if (Input.GetKey(KeyCode.S))
            this.yMov = -5;

        if (Input.GetKeyUp(KeyCode.A))
            this.xMov = 0;
        if (Input.GetKeyUp(KeyCode.D))
            this.xMov = 0;
        if (Input.GetKeyUp(KeyCode.W))
            this.yMov = 0;
        if (Input.GetKeyUp(KeyCode.S))
            this.yMov = 0;

        this.MovePosition(new Vector2(xMov, yMov));
    }
}
