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

    [SerializeField] Player player;

    private const float MAX_DISTANCE_FOR_WALK = 5f;
    private const float SOUND_COOLDOWN_VALUE = 2f;

    private Coroutine listenCoroutine;

    private bool allowMove = true;
    private bool movingInDirection = false;
    private bool canListenToSound = true;

    private float soundCooldown = 0f;

    private void Start()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();
        this.Speed = 5f;
        this.soundCooldown = 0f;
        StartListeningToSound();
    }


    private void Update()
    {
        if ((int) this.soundCooldown > 0f)
        {
            this.soundCooldown -= Time.deltaTime;
        } else
        {
            if (!this.canListenToSound)
            {
                this.soundCooldown = 0f;
                this.canListenToSound = true;
                //Debug.Log("CAN LISTEN TO SOUND AGAIN!");
                StartListeningToSound();
            }
        }
    }

    private void FixedUpdate()
    {
        if (allowMove)
            FollowPlayer();

        if (this.movingInDirection)
        {
            if (Vector2.Distance(transform.position, this.player.transform.position) >= MAX_DISTANCE_FOR_WALK)
            {
                this.movingInDirection = false;
                this.MovePosition(new Vector2(0f, 0f));
            }
        }
    }

    private void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, this.player.transform.position) > 1.5f)
        {
            this.FollowTarget(this.player.transform, this.Speed);
        }
    }

    private void EvaluateSound()
    {
        switch (lastSoundHeard)
        {
            case SoundType.RED:
                HoldPosition();
                break;
            case SoundType.GREEN:
                ComeToMe();
                break;
            case SoundType.YELLOW:
                MoveInDirection();
                break;
            case SoundType.BLUE:
                ListenAndRepeat();
                break;
            default:
                break;
        }

        lastSoundHeard = SoundType.NONE;
        //StartListeningToSound();
    }

    private IEnumerator ListenToSound()
    {
        yield return new WaitUntil(() => { return this.lastSoundHeard != SoundType.NONE && this.canListenToSound; });

        if (this.canListenToSound)
        {
            this.soundCooldown = SOUND_COOLDOWN_VALUE;
            this.canListenToSound = false;
            EvaluateSound();
        }
    }

    private void StartListeningToSound()
    {
        this.listenCoroutine = StartCoroutine(ListenToSound());
    }

    private void StopListeningToSound()
    {
        StopCoroutine(this.listenCoroutine);
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

    private void MoveInDirection()
    {
        PlayerOrientation direction = player.CurrOrientation;
        HoldPosition();
        float xMov = 0;
        float yMov = 0;
        switch (direction)
        {
            case PlayerOrientation.UP:
                xMov = 0;
                yMov = this.Speed;
                break;
            case PlayerOrientation.DOWN:
                xMov = 0;
                yMov = -this.Speed;
                break;
            case PlayerOrientation.LEFT:
                xMov = -this.Speed;
                yMov = 0;
                break;
            case PlayerOrientation.RIGHT:
                xMov = this.Speed;
                yMov = 0;
                break;
            default:
                xMov = 0;
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

    #region Override Collider Events
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        //Debug.Log("Last Sound Heard: " + this.lastSoundHeard.ToString());
    }
    #endregion
}
