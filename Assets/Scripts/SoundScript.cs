using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : Poolable
{
    [SerializeField] float lifetime;
    [SerializeField] float speed;
    [SerializeField] SoundType soundType;

    float time;
    Rigidbody2D rb;

    public override void OnCreate()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public override void OnGet()
    {
        time = lifetime; 
    }
    public override void OnReturn()
    {

    }

    //Should be called after poolable is rotated
    public void MoveForward()
    {
        rb.velocity = transform.up * speed;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            pool.ReturnPoolObject(gameObject);
        }
    }


    public SoundType GetSoundType() { return soundType; }
}

public enum SoundType
{
    NONE,
    RED,
    GREEN,
    YELLOW,
    BLUE
}
