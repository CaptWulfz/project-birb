using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerOrientation
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}
public class Player : Entity
{
    [SerializeField] List<ObjectPool> soundPools;
    [SerializeField] GameObject stonesVertical;
    [SerializeField] GameObject stonesHorizontal;
    private PlayerOrientation currOrientation;
    public PlayerOrientation CurrOrientation
    {
        get { return this.currOrientation; }
    }
    Animator a;
    Animation anim;
    SpriteRenderer sr;
    
    private void Start()
    {
        Initialize();
        a = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponentInChildren<Animation>();
    }

    protected override void Initialize()
    {
        base.Initialize();
        this.Speed = 5f;
        this.currOrientation = PlayerOrientation.UP;
        this.EntityControls = InputManager.Instance.GetControls();
        this.EntityControls.Player.Enable();
        this.EntityControls.Player.PlayMusic.performed += PlayMusic;
    }

    private void Update()
    {
        DetermineOrientation();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 move = this.EntityControls.Player.Movement.ReadValue<Vector2>();
        this.MovePosition(move * this.Speed);
        foreach(AnimatorControllerParameter parameter in a.parameters) {            
            a.SetBool(parameter.name, false);
        }
        switch (move) {
            case Vector2 v when v.Equals(Vector2.up):
                a.SetBool("Up", true);
                sr.flipX = false;
                stonesVertical.SetActive(true);
                stonesHorizontal.SetActive(false);
                break;
            case Vector2 v when v.Equals(Vector2.down):
                a.SetBool("Down", true);
                sr.flipX = false;
                stonesVertical.SetActive(true);
                stonesHorizontal.SetActive(false);
                break;
            case Vector2 v when v.Equals(Vector2.left) || v.x.Equals(-0.707107f):
                a.SetBool("Left", true);
                sr.flipX = true;
                stonesVertical.SetActive(false);
                stonesHorizontal.SetActive(true);
                stonesHorizontal.transform.GetChild(0).gameObject.SetActive(true);
                stonesHorizontal.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case Vector2 v when v.Equals(Vector2.right) || v.x.Equals(0.707107f):
                a.SetBool("Right", true);
                sr.flipX = false;
                stonesVertical.SetActive(false);
                stonesHorizontal.SetActive(true);
                stonesHorizontal.transform.GetChild(0).gameObject.SetActive(false);
                stonesHorizontal.transform.GetChild(1).gameObject.SetActive(true);
                break;
        }
    }

    private void DetermineOrientation()
    {
        if (this.EntityControls.Player.FaceUp.WasPressedThisFrame())
            this.currOrientation = PlayerOrientation.UP;
        else if (this.EntityControls.Player.FaceDown.WasPressedThisFrame())
            this.currOrientation = PlayerOrientation.DOWN;
        else if (this.EntityControls.Player.FaceLeft.WasPressedThisFrame())
            this.currOrientation = PlayerOrientation.LEFT;
        else if (this.EntityControls.Player.FaceRight.WasPressedThisFrame())
            this.currOrientation = PlayerOrientation.RIGHT;
    }

    void PlayMusic(InputAction.CallbackContext context)
    {
        bool note1 = this.EntityControls.Player.Note1.ReadValue<float>() != 0;
        bool note2 = this.EntityControls.Player.Note2.ReadValue<float>() != 0;

        if (note1 && note2)
            MakeSound(SoundType.BLUE);
        else if (note1)
            MakeSound(SoundType.YELLOW);
        else if (note2)
            MakeSound(SoundType.GREEN);
        else
            MakeSound(SoundType.RED);
    }

    void MakeSound(SoundType soundType)
    {
        anim.Play();
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
    }

    void PlayFlute(SoundType type)
    {
        string sfxKey = "";
        switch (type)
        {
            case SoundType.RED:
                sfxKey = SFXKeys.ROCK_FLUTE_00;
                break;
            case SoundType.GREEN:
                sfxKey = SFXKeys.ROCK_FLUTE_01;
                break;
            case SoundType.YELLOW:
                sfxKey = SFXKeys.ROCK_FLUTE_10;
                break;
            case SoundType.BLUE:
                sfxKey = SFXKeys.ROCK_FLUTE_11;
                break;
        }

        AudioManager.Instance.PlayAudio(AudioKeys.SFX, sfxKey);
    }
}
