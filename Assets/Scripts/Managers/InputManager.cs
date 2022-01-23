using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private Controls controls = null;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (controls == null)
            controls = new Controls();
    }
    
    public IEnumerator GetControlsCoroutine()
    {
        yield return new WaitUntil(() => { return this.controls != null; });
    }

    public Controls GetControls()
    {
        if (this.controls == null)
            Initialize();

        return this.controls;
    }
}
