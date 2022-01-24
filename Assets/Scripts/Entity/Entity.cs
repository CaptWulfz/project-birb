using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigidBody;

    protected SoundType lastSoundHeard;

    private Controls controls;
    public Controls EntityControls
    {
        get { return this.controls; }
        set { this.controls = value; }
    }

    private float speed = 5f;
    protected float Speed
    {
        get { return this.speed; }
        set { this.speed = value; }
    }

    protected virtual void Initialize()
    {
        this.lastSoundHeard = SoundType.NONE;
    }

    protected void MovePosition(Vector2 movement)
    {
        this.rigidBody.velocity = movement;
    }

    protected void FollowTarget(Transform target, float speed)
    {
        this.rigidBody.MovePosition(Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime));
    }

    protected void FaceTarget(Transform target)
    {
        this.transform.LookAt(transform.position + new Vector3(0, 0, 1), target.position - this.transform.position);
    }

    #region Collision Events

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(string.Format("Collision Detected! Entity {0} got hit by {1}", this.gameObject.name, collision.gameObject.name));
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagNames.SOUND_TAG)
        {
            SoundScript sound = collision.gameObject.GetComponent<SoundScript>();
            if (sound.OwnerSource != this.gameObject.tag)
                this.lastSoundHeard = collision.gameObject.GetComponent<SoundScript>().GetSoundType();
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    #endregion
}
