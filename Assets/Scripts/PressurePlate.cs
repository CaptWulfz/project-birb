using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Lock
{
    [SerializeField] GameObject triggeredObject;
    [SerializeField] string tagName;

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject colGO = collider.gameObject;
        if (colGO.tag != tagName)
            return;

        triggeredObject.SetActive(true);
        activated = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        GameObject colGO = collider.gameObject;
        if (colGO.tag != tagName)
            return;

        triggeredObject.SetActive(false);
        activated = false;
    }
}
