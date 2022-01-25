using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneReset : MonoBehaviour
{
    [SerializeField] RuneScript runeScript;
    [SerializeField] GameObject cursor;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject != cursor)
            return;
        runeScript.Reset();
    }
}
