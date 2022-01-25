using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] List<Lock> locks;

    [SerializeField] float distanceMoved;
    [SerializeField] float timeMoved;

    Rigidbody2D rb;
    bool activated;
    float time;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!activated)
        {
            CheckLocks();
            return;
        }

        if (time > 0)
        {
            time -= Time.deltaTime;
            return;
        }

        rb.velocity = Vector2.zero;
    }

    void CheckLocks()
    {
        foreach(Lock locc in locks)
        {
            if (!locc.IsActivated())
                return;
        }
        OpenDoor();
    }
   
    void OpenDoor()
    {
        rb.velocity = new Vector3(distanceMoved/timeMoved, 0, 0);
        time = timeMoved;
        activated = true;
    }

}
