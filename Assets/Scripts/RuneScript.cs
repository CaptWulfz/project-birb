using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RuneScript : Lock
{
    [SerializeField] float orbitInterval;
    [SerializeField] Lock lockObject;
    [SerializeField] Transform cursorArm;
    [SerializeField] Transform cursor;
    [SerializeField] List<GameObject> cursorTypes;
    [SerializeField] List<RuneNote> notes;

    Animator a;
    bool started;
    bool onPlate = false;

    void Awake()
    {
        //Input system shenanigans
        a = GetComponent<Animator>();
    }
    void OnEnable()
    {
        cursorArm.rotation = Quaternion.identity;
        started = false;
        this.onPlate = false;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (done) {
            lockObject.SetDone();
            a.SetBool("End", true);
            this.enabled = false;
            this.onPlate = false;
            InputManager.Instance.GetControls().Player.PlayMusic.performed -= PlayMusic;
            return;
        }
        if (!lockObject.IsActivated() && started && !activated) {
            cursorArm.rotation = Quaternion.identity;
            started = false;
            AudioManager.Instance.PlayAudio(AudioKeys.SFX, SFXKeys.ANCIENT_RUNE_PUZZLE_FAILED);
            InputManager.Instance.GetControls().Player.PlayMusic.performed -= PlayMusic;
            onPlate = false;
            Reset();
            a.SetBool("Start", false);
            return;
        }

        if (lockObject.IsActivated() && !onPlate)
        {
            this.onPlate = true;
            InputManager.Instance.GetControls().Player.PlayMusic.performed += PlayMusic;
        }

        if (started) {
            cursorArm.Rotate(0, 0, -360 / orbitInterval * Time.deltaTime);
            a.SetBool("Start", true);
            SuccessCheck();
        } else if (SuccessCheck() > 0)
            started = true; 
    }

    //checks if all notes are activated
    int SuccessCheck()
    {
        int successes = 0;
        foreach (RuneNote note in notes)
        {
            if (note.IsActivated())    
                successes++;
        }
        if(successes >= notes.Count)
            activated = true;

        return successes;
    }

    //resets
    public void Reset()
    {
        foreach (RuneNote note in notes)
            note.SetActivated(false);
    }

    //Executed when SPACE is pressed
    void PlayMusic(InputAction.CallbackContext context)
    {
        //Input system shenanigans
        bool note1 = InputManager.Instance.GetControls().Player.Note1.ReadValue<float>() != 0;
        bool note2 = InputManager.Instance.GetControls().Player.Note2.ReadValue<float>() != 0;

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


}
