using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Lock
{
    [SerializeField] string tagName;
    [Header("Sprites")]
    [SerializeField] Sprite off;
    [SerializeField] Sprite on;
    SpriteRenderer sr;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject colGO = collider.gameObject;
        if (colGO.tag != tagName)
            return;

        activated = true;
        sr.sprite = on;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        GameObject colGO = collider.gameObject;
        if (colGO.tag != tagName)
            return;

        activated = false;
        sr.sprite = off;
    }
}
