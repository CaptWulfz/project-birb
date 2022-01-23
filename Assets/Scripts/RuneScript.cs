using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RuneScript : MonoBehaviour
{
    [SerializeField] float orbitInterval;

    [SerializeField] Transform cursorArm;
    [SerializeField] Transform cursor;
    
    [SerializeField] List<GameObject> cursorTypes;
    [SerializeField] List<RuneNote> notes;

    Controls controls;
    float oldRot;

    bool activated;

    void Awake()
    { 
        //Input system shenanigans
        controls = new Controls();
        controls.Player.Enable();
        controls.Player.PlayMusic.performed += PlayMusic;
    }
    void OnEnable()
    {
        cursorArm.rotation = Quaternion.identity;
        foreach (RuneNote note in notes)
            note.SetActivated(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
            return;

        cursorArm.Rotate(0, 0, -360 / orbitInterval * Time.deltaTime);
        SuccessCheck();
        ResetCheck();
    }

    //checks if all notes are activated
    void SuccessCheck()
    {
        foreach (RuneNote note in notes)
        {
            if (!note.IsActivated())
                return;
        }
        activated = true;   
    }

    //checks if it does a full revolution and resets 
    void ResetCheck()
    {
        float currentRot = cursorArm.rotation.eulerAngles.z;
        if (oldRot < 180 && currentRot >= 180)
        {
            foreach (RuneNote note in notes)
                note.SetActivated(false);
        }
        oldRot = currentRot;
    }

    //Executed when SPACE is pressed
    void PlayMusic(InputAction.CallbackContext context)
    {
        //Input system shenanigans
        bool note1 = controls.Player.Note1.ReadValue<float>() != 0;
        bool note2 = controls.Player.Note2.ReadValue<float>() != 0;

        if (note1 && note2)
            StartCoroutine(MakeSound(3));
        else if (note1)
            StartCoroutine(MakeSound(2));
        else if (note2)
            StartCoroutine(MakeSound(1));
        else
            StartCoroutine(MakeSound(0));
    }

    IEnumerator MakeSound(int type)
    {
        cursorTypes[type].gameObject.SetActive(true);
        cursorTypes[type].transform.position = cursor.position;

        yield return new WaitForSeconds(0.05f);
        cursorTypes[type].transform.position = transform.position;
        cursorTypes[type].SetActive(false);
    }

    public bool IsActivated() { return activated; }
}
