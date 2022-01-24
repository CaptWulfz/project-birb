using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] List<ObjectPool> soundPools;

    Controls controls;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        controls = new Controls();
        controls.Player.Enable();
        controls.Player.PlayMusic.performed += PlayMusic;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 inputVector = controls.Player.Movement.ReadValue<Vector2>();
        rb.velocity = inputVector * speed;
    }


    void PlayMusic(InputAction.CallbackContext context)
    {   

        bool note1 = controls.Player.Note1.ReadValue<float>() != 0;
        bool note2 = controls.Player.Note2.ReadValue<float>() != 0;

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

        for(int i = 0; i < numberOfBullets; i++)
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
