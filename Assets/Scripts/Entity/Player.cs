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

    private PlayerOrientation currOrientation;
    public PlayerOrientation CurrOrientation
    {
        get { return this.currOrientation; }
    }
    
    private void Start()
    {
        Initialize();
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

        //Debug.Log(string.Format("Orientation: {0}", this.currOrientation.ToString()));
    }

    void PlayMusic(InputAction.CallbackContext context)
    {

        bool note1 = this.EntityControls.Player.Note1.ReadValue<float>() != 0;
        bool note2 = this.EntityControls.Player.Note2.ReadValue<float>() != 0;

        if (note1 && note2)
            MakeSound(3);
        else if (note1)
            MakeSound(2);
        else if (note2)
            MakeSound(1);
        else
            MakeSound(0);
    }

    void MakeSound(int SoundType)
    {
        int numberOfBullets = 120;
        ObjectPool pool = soundPools[SoundType];

        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject soundBullet = pool.GetPoolObject();
            soundBullet.transform.position = transform.position;
            soundBullet.transform.rotation = transform.rotation;
            soundBullet.transform.Rotate(0, 0, (360 / numberOfBullets) * i);

            SoundScript soundScript = soundBullet.GetComponent<SoundScript>();
            soundScript.MoveForward();
        }
    }
}
