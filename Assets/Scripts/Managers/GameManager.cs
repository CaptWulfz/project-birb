using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Credits credits;
    [SerializeField] Camera cam;

    private const int MAX_LEVEL = 4;
    private const string LEVEL_TEMPLATE = "Level{0}Mockup";

    private int level;

    public void Start()
    {
        InitializeGame(4); 
        Physics2D.IgnoreLayerCollision(8, 9, true);
        AudioManager.Instance.PlayAudio(AudioKeys.MUSIC, MusicKeys.THEME);
        AudioManager.Instance.ToggleLoop(AudioKeys.MUSIC, true);
        DontDestroyOnLoad(this);
    }

    public void InitializeGame(int level)
    {
        this.level = level;
        this.cam.gameObject.SetActive(false);
        this.credits.gameObject.SetActive(false);
        InputManager.Instance.GetControls().Player.Enable();
        LoadLevel();
    }

    public void NextLevel()
    {
        if (level >= MAX_LEVEL)
        {
            InputManager.Instance.GetControls().Player.Disable();
            UnloadLevel();
            this.credits.gameObject.SetActive(true);
            this.cam.gameObject.SetActive(true);
            return;
//#if UNITY_EDITOR
//            UnityEditor.EditorApplication.isPlaying = false;
//#else
//            Application.Quit();
//#endif
        }

        UnloadLevel();
        level++;
        LoadLevel();
    }
    
    private void UnloadLevel()
    {
        string name = string.Format(LEVEL_TEMPLATE, level);
        SceneManager.UnloadSceneAsync(name);
    }

    private void LoadLevel()
    {
        string name = string.Format(LEVEL_TEMPLATE, level);
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
        //InputManager.Instance.GetControls().Player.Enable();
    }
}
