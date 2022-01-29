using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneNote : MonoBehaviour
{
    [SerializeField] int noteType;
    [SerializeField] bool activated;
    [Header("Sprites")]
    [SerializeField] Sprite off;
    [SerializeField] Sprite on;

    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update() {
        sr.sprite = activated ? on : off;
    }

    public int GetNoteType() { return noteType; }
    public bool IsActivated() { return activated; }
    public void SetActivated(bool activated) {
        this.activated = activated; 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name != noteType.ToString())
            return;

        SetActivated(true);

        //string key = SFXKeys.ANCIENT_RUNE_FLUTE_00;
        //switch (noteType)
        //{
        //    case 0:
        //        key = SFXKeys.ANCIENT_RUNE_FLUTE_00;
        //        break;
        //    case 1:
        //        key = SFXKeys.ANCIENT_RUNE_FLUTE_01;
        //        break;
        //    case 2:
        //        key = SFXKeys.ANCIENT_RUNE_FLUTE_10;
        //        break;
        //    case 3:
        //        key = SFXKeys.ANCIENT_RUNE_FLUTE_11;
        //        break;
        //}

        //AudioManager.Instance.PlayAudio(AudioKeys.SFX, key);

    }
}
