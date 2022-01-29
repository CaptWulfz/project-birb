using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] List<Lock> locks;
    [SerializeField] GameObject doneIndicator;
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
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
            if (transform.position == target) {
                this.enabled = false;
                return;
            }
            foreach(Transform child in transform) {
                child.rotation = Quaternion.RotateTowards(child.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime*18);
            }
            doneIndicator.SetActive(true);
        }
    }

    void CheckLocks()
    {
        foreach(Lock locc in locks) {
            if (!locc.IsActivated())
                return;
        }
        foreach(Lock locc in locks) {
            locc.SetDone();
        }
        OpenDoor();
    }
   
    void OpenDoor() {
        activated = true;
        AudioManager.Instance.PlayAudio(AudioKeys.SFX, SFXKeys.ANCIENT_RUNE_PUZZLE_SOLVED);
    }

}
