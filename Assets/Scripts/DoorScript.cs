using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] List<Lock> locks;
    bool activated;
    Vector3 target;

    void Start() {
        target = transform.position + new Vector3(5, 0, 0);
    }

    void Update()
    {
        if (!activated) {
            CheckLocks();
            return;
        } else {
            transform.parent.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime*18);
        }
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
   
    void OpenDoor() {
        activated = true;
    }

}
