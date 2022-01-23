using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneNote : MonoBehaviour
{
    [SerializeField] int noteType;
    [SerializeField] bool activated;
    [SerializeField] GameObject signal;

    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public int GetNoteType() { return noteType; }
    public bool IsActivated() { return activated; }
    public void SetActivated(bool activated) {
        if (activated)
            signal.SetActive(true);
        else
            signal.SetActive(false);

        this.activated = activated; 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (int.Parse(collider.gameObject.name) != noteType)
            return;

        SetActivated(true);
    }
}
