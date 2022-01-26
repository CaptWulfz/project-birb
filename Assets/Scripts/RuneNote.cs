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
    }
}
