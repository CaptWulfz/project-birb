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

    private class SoundMimic
    {
        float time;
        public float Time
        {
            get { return this.time; }
        }

        SoundType sound;
        public SoundType Sound
        {
            get { return this.sound; }
        }

        public SoundMimic(float time, SoundType type)
        {
            this.time = time;
            this.sound = type;
        }

    }

    [SerializeField] Player player;
    [SerializeField] List<ObjectPool> soundPools;

    private const float DISTANCE_FROM_PLAYER = 1.5f;
    private const float SOUND_COOLDOWN_VALUE = 2f;
    private const float MIMIC_SOUND_DELAY = 3f;
    private const int MAX_SOUNDS_TO_MIMIC = 4;

    private Queue<SoundMimic> mimicList;
    private SoundMimic currSoundToMimic;

    private Coroutine listenCoroutine;

    private bool allowMove = true;
    private bool movingInDirection = false;
    private bool canListenToSound = true;

    private bool isListeningAndRepeat = false;
    private bool startMimicTiming = false;
    private bool startMimicSounds = false;

    private float soundCooldown = 0f;
    private float mimicTiming = 0f;
    private float mimicSoundDelay = 0f;

    Vector2 target;
    Animator a;
    SpriteRenderer sr;

    private void Start()
    {
        a = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();
        this.Speed = 5f;
        this.soundCooldown = 0f;
        this.mimicSoundDelay = MIMIC_SOUND_DELAY;
        this.mimicList = new Queue<SoundMimic>();
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
                Debug.Log("CAN LISTEN TO SOUND AGAIN!");
                if (this.isListeningAndRepeat)
                {
                    Debug.Log("I AM NOW LISTENING AND REPEATING!!!");
                    HoldPosition();
                    this.startMimicTiming = true;
                }
                StartListeningToSound();
            }
        }

        if (this.startMimicTiming)
        {
            if (this.mimicList.Count > 0 && this.mimicList.Count < MAX_SOUNDS_TO_MIMIC)
            {
                this.mimicTiming += Time.deltaTime;
            } else if (this.mimicList.Count >= MAX_SOUNDS_TO_MIMIC)
            {
                this.startMimicTiming = false;
                this.startMimicSounds = true;
                this.mimicTiming = 0f;
            }
        }

        if (this.startMimicSounds)
        {
            if (mimicSoundDelay > 0)
            {
                this.mimicSoundDelay -= Time.deltaTime;
            } else
            {
                MimicSounds();
            }
        }
    }

    private void FixedUpdate()
    {
        if (allowMove)
            FollowPlayer();

        if (this.movingInDirection)
        {
            if (Vector2.Distance(transform.position, target) < 0.5f)
            {
                this.movingInDirection = false;
                this.MovePosition(new Vector2(0f, 0f));
                a.SetBool("Fly", false);
            }
        }
    }

    private void MimicSounds() 
    {
        //StopListeningToSound();
        if (this.currSoundToMimic == null && this.mimicList.Count > 0)
            this.currSoundToMimic = this.mimicList.Dequeue();

        if (this.mimicList.Count + 1 == MAX_SOUNDS_TO_MIMIC)
        {
            MakeSound(this.currSoundToMimic.Sound);
        } else
        {
            if (this.currSoundToMimic != null)
            {
                this.mimicTiming += Time.deltaTime;
                float diff = Mathf.Abs(this.mimicTiming - this.currSoundToMimic.Time);
                //Debug.Log("QQQ MIMIC TIMING: " + this.mimicTiming + " | CURR MIMIC TIME: " + this.currSoundToMimic.Time + " | DIFFERENCE: " + diff);
                if (diff < 0.05 && Mathf.Floor(this.mimicTiming) == Mathf.Floor(this.currSoundToMimic.Time))
                {
                    MakeSound(this.currSoundToMimic.Sound);
                }
            } else
            {
                //Debug.Log("Sounds Done, Come back to me!");
                ResetListenAndRepeat();
            }

        }
    }

    private void ResetListenAndRepeat()
    {
        this.startMimicSounds = false;
        this.isListeningAndRepeat = false;
        this.mimicSoundDelay = MIMIC_SOUND_DELAY;
        this.mimicTiming = 0f;

        this.lastSoundHeard = SoundType.NONE;

        this.soundCooldown = SOUND_COOLDOWN_VALUE + 2f;
        this.canListenToSound = false;

        ComeToMe();
    }

    private void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, this.player.transform.position) > DISTANCE_FROM_PLAYER)
        {
            this.FollowTarget(this.player.transform, this.Speed);
            float dir = (this.player.transform.position.x - transform.position.x);
            sr.flipX = (dir > 0f) ? false : true;
            a.SetBool("Walk", true);
        } else
            a.SetBool("Walk", false);
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

        this.lastSoundHeard = SoundType.NONE;
        //StartListeningToSound();
    }

    private IEnumerator ListenToSound()
    {
        yield return new WaitUntil(() => { return this.lastSoundHeard != SoundType.NONE && this.canListenToSound && !movingInDirection; });

        if (this.canListenToSound)
        {
            if (!this.isListeningAndRepeat)
            {
                this.soundCooldown = SOUND_COOLDOWN_VALUE;
                this.canListenToSound = false;
                EvaluateSound();
            } else
            {
                if (this.startMimicTiming)
                {
                    if (this.mimicList.Count == 0)
                    {
                        this.mimicList.Enqueue(new SoundMimic(0f, this.lastSoundHeard));
                    } else if (this.mimicList.Count > 0 && this.mimicList.Count < MAX_SOUNDS_TO_MIMIC)
                    {
                        this.mimicList.Enqueue(new SoundMimic(this.mimicTiming, this.lastSoundHeard));
                    }
                    this.lastSoundHeard = SoundType.NONE;
                    if (this.mimicList.Count < MAX_SOUNDS_TO_MIMIC)
                        StartListeningToSound();
                }
            }
        }
    }

    private void StartListeningToSound()
    {
        this.listenCoroutine = StartCoroutine(ListenToSound());
    }

    private void StopListeningToSound()
    {
        if (this.listenCoroutine != null)
            StopCoroutine(this.listenCoroutine);
    }

    #region Commands
    private void HoldPosition()
    {
        //Debug.Log("Hold Position");
        this.allowMove = false;
        a.SetBool("Walk", false);
    }

    private void ComeToMe()
    {
        //Debug.Log("Come to Me");
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
                a.SetBool("Fly", true);
                break;
            case PlayerOrientation.DOWN:
                xMov = 0;
                yMov = -this.Speed;
                a.SetBool("Fly", true);
                break;
            case PlayerOrientation.LEFT:
                xMov = -this.Speed;
                yMov = 0;
                a.SetBool("Fly", true);
                sr.flipX = true;
                break;
            case PlayerOrientation.RIGHT:
                xMov = this.Speed;
                yMov = 0;
                a.SetBool("Fly", true);
                sr.flipX = false;
                break;
            default:
                xMov = 0;
                yMov = 0;
                break;
        }
        target = new Vector2(transform.position.x + xMov, transform.position.y + yMov);
        this.MovePosition(new Vector2(xMov, yMov));
        this.movingInDirection = true;
    }

    private void ListenAndRepeat()
    {
        this.mimicList.Clear();
        this.isListeningAndRepeat = true;
    }
    #endregion

    #region Sounding Functions
    void MakeSound(SoundType soundType)
    {
        int numberOfBullets = 120;
        int index = (int)soundType - 1;
        ObjectPool pool = soundPools[index];

        PlayFlute(soundType);

        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject soundBullet = pool.GetPoolObject();
            soundBullet.transform.position = transform.position;
            soundBullet.transform.rotation = transform.rotation;
            soundBullet.transform.Rotate(0, 0, (360 / numberOfBullets) * i);

            SoundScript soundScript = soundBullet.GetComponent<SoundScript>();
            soundScript.OwnerSource = this.gameObject.tag;
            soundScript.MoveForward();
        }

        this.currSoundToMimic = null;
    }

    void PlayFlute(SoundType type)
    {
        string sfxKey = "";
        switch (type)
        {
            case SoundType.RED:
                sfxKey = SFXKeys.PHOENIX_RESPONSE_00;
                break;
            case SoundType.GREEN:
                sfxKey = SFXKeys.PHOENIX_RESPONSE_01;
                break;
            case SoundType.YELLOW:
                sfxKey = SFXKeys.PHOENIX_RESPONSE_10;
                break;
            case SoundType.BLUE:
                sfxKey = SFXKeys.PHOENIX_RESPONSE_11;
                break;
        }

        AudioManager.Instance.PlayAudio(AudioKeys.SFX, sfxKey);
    }
    #endregion

    #region Override Collider Events
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (canListenToSound)
            base.OnTriggerEnter2D(collision);
        //Debug.Log("Last Sound Heard: " + this.lastSoundHeard.ToString());
    }
    #endregion
}
