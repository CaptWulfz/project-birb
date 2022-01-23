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
    
    private bool allowMove = true;
    private bool movingInDirection = false;

    private void Start()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();
        this.Speed = 5f;
        this.EntityControls = InputManager.Instance.GetControls();
        this.EntityControls.Phoenix.Enable();
    }


    private void Update()
    {
        if (this.EntityControls.Phoenix.ToggleHold.WasReleasedThisFrame())
        {
            if (this.allowMove)
                HoldPosition();
            else
                ComeToMe();
        }

        if (this.EntityControls.Phoenix.Move.WasReleasedThisFrame())
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
            this.FollowTarget(this.player, this.Speed);
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
                xMov = -this.Speed;
                yMov = 0;
                break;
            case BirdDirection.RIGHT:
                xMov = this.Speed;
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
