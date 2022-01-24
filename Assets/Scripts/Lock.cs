using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] protected bool activated;
    public bool IsActivated() { return activated; }
}
