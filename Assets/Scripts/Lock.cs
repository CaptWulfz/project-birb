using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    protected bool activated = false;
    protected bool done = false;
    public bool IsActivated() { return activated; }
    public void SetDone() { done = true; }
}
