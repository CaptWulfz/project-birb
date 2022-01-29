using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePlate : Lock
{
    [SerializeField] Phoenix phoenix;
    [Header("Plate Sprites")]
    [SerializeField] Sprite offPlate;
    [SerializeField] Sprite onPlate;
    SpriteRenderer srPlate;
    [Header("Frame Sprites")]
    [SerializeField] Sprite offFrame;
    [SerializeField] Sprite onFrame;
    [SerializeField] SpriteRenderer srFrame;

    void Start() {
        srPlate = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (done)
            return;
        GameObject colGO = collider.gameObject;
        if (colGO.tag != "Player")
            return;

        activated = true;
        srPlate.sprite = onPlate;
        srFrame.sprite = onFrame;
        phoenix.onRunePlate = true;
        AudioManager.Instance.PlayAudio(AudioKeys.SFX, SFXKeys.ANCIENT_RUNE_ACTIVATE);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (done) {
            phoenix.onRunePlate = false;
            return;
        }
        GameObject colGO = collider.gameObject;
        if (colGO.tag != "Player")
            return;

        phoenix.onRunePlate = false;
        activated = false;
        srPlate.sprite = offPlate;
        srFrame.sprite = offFrame;
    }
}
