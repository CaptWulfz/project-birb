using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private const int MAX_LEVEL = 4;
    private const string LEVEL_TEMPLATE = "Level{0}Mockup";

    private int level;

    public void Start()
    {
        level = 4;
        LoadLevel();
        AudioManager.Instance.PlayAudio(AudioKeys.MUSIC, MusicKeys.THEME);
        AudioManager.Instance.ToggleLoop(AudioKeys.MUSIC, true);
        DontDestroyOnLoad(this);
    }

    public void NextLevel()
    {
        if (level >= MAX_LEVEL)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
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
