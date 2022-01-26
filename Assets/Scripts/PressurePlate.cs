using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Lock
{
    [SerializeField] GameObject pressure;
    [Header("Plate Sprites")]
    [SerializeField] Sprite offPlate;
    [SerializeField] Sprite onPlate;
    SpriteRenderer srPlate;

    bool player = false;
    bool phoenix = false;

    void Start() {
        srPlate = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (done)
            return;
        GameObject colGO = collider.gameObject;
        if (colGO.tag == "Player")
            player = true;
        else if (colGO.tag == "Phoenix")
            phoenix = true;
        else
            return;

        activated = true;
        srPlate.sprite = onPlate;
        pressure.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (done)
            return;
        GameObject colGO = collider.gameObject;
        if (colGO.tag == "Player")
            player = false;
        else if (colGO.tag == "Phoenix")
            phoenix = false;
        else
            return;
        
        if (player || phoenix)
            return;

        activated = false;
        srPlate.sprite = offPlate;
        pressure.SetActive(false);
    }
}
