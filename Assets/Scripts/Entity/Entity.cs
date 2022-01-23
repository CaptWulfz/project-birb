using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigidBody;

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
}
