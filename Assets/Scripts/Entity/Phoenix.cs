using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Phoenix : Entity
{
    private enum BirdDirection
    {
        UP,
        DOWN,
        LEFT, 
        RIGHT
    }

    [SerializeField] Transform player;

    private const float MAX_DISTANCE_FOR_WALK = 5f;
    private const float VELOCITY = 5f;
    
    private bool allowMove = true;
    private bool movingInDirection = false;
    Controls controls;

    private void Start()
    {
        controls = new Controls();
        controls.Phoenix.Enable();
    }

    private void Update()
    {
        if (controls.Phoenix.ToggleHold.WasReleasedThisFrame())
        {
            if (this.allowMove)
                HoldPosition();
            else
                ComeToMe();
        }

        if (controls.Phoenix.Move.WasReleasedThisFrame())
        {
            MoveInDirection(BirdDirection.LEFT);
        } 
    }

    private void FixedUpdate()
    {
        if (allowMove)
            FollowPlayer();

        if (this.movingInDirection)
        {
            if (Vector2.Distance(transform.position, this.player.position) >= MAX_DISTANCE_FOR_WALK)
            {
                this.movingInDirection = false;
                this.MovePosition(new Vector2(0f, 0f));
            }
        }
    }

    private void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, this.player.position) > 1.5f)
        {
            this.FollowTarget(this.player, VELOCITY);
        }
    }

    #region Commands
    private void HoldPosition()
    {
        this.allowMove = false;
    }

    private void ComeToMe()
    {
        this.allowMove = true;
    }

    private void MoveInDirection(BirdDirection direction)
    {
        HoldPosition();
        float xMov = 0;
        float yMov = 0;
        switch (direction)
        {
            case BirdDirection.LEFT:
                xMov = -VELOCITY;
                yMov = 0;
                break;
            case BirdDirection.RIGHT:
                xMov = VELOCITY;
                yMov = 0;
                break;
        }

        this.MovePosition(new Vector2(xMov, yMov));
        this.movingInDirection = true;
    }

    private void ListenAndRepeat()
    {

    }
    #endregion
}
