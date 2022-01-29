using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Asset")]
    [SerializeField] AudioMap audioMap;

    [Header("Audio Sources")]
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource musicSource;

    Dictionary<string, AudioClip> sfx;
    Dictionary<string, AudioClip> music;

    private void Start()
    {
        Initialize();   
    }

    #region Initialization
    public void Initialize()
    {
        if (sfx == null)
            sfx = new Dictionary<string, AudioClip>();

        if (music == null)
            music = new Dictionary<string, AudioClip>();

        sfx.Clear();
        foreach (AudioMap.AudioEntry entry in this.audioMap.SFX)
        {
            //Debug.Log("QQQ Loading Key: " + entry.key + " | CLIP: " + entry.source);
            this.sfx.Add(entry.key, entry.source);
        }

        music.Clear();
        foreach (AudioMap.AudioEntry entry in this.audioMap.Music)
        {
            this.music.Add(entry.key, entry.source);
        }

        DontDestroyOnLoad(this);
    }
    #endregion

    #region Functions
    public void PlayAudio(string sourceKey, string clipName)
    {
        AudioSource source = GetSource(sourceKey);
        Dictionary<string, AudioClip> dict = GetAudioDict(sourceKey);
        source.clip = dict[clipName];
        source.Play();
    }

    public void SetVolume(string key, float value)
    {
        AudioSource source = GetSource(key);
        source.volume = value;
    }

    public void ToggleLoop(string sourceKey, bool value)
    {
        AudioSource source = GetSource(sourceKey);
        source.loop = value;
    }
    #endregion

    #region Helpers
    private AudioSource GetSource(string key)
    {
        AudioSource source = null;

        switch (key)
        {
            case AudioKeys.SFX:
                source = this.sfxSource;
                break;
            case AudioKeys.MUSIC:
                source = this.musicSource;
                break;
        }

        return source;
    }

    private Dictionary<string, AudioClip> GetAudioDict(string key)
    {
        Dictionary<string, AudioClip> dict = null;

        switch (key)
        {
            case AudioKeys.SFX:
                dict = this.sfx;
                break;
            case AudioKeys.MUSIC:
                dict = this.music;
                break;
        }

        return dict;
    }
    #endregion
}

public class AudioKeys
{
    public const string SFX = "SFX";
    public const string MUSIC = "MUSIC";
}

public class SFXKeys
{
    // Rock SFX
    public const string ROCK_FLUTE_00 = "Rock_Flute_00";
    public const string ROCK_FLUTE_01 = "Rock_Flute_01";
    public const string ROCK_FLUTE_10 = "Rock_Flute_10";
    public const string ROCK_FLUTE_11 = "Rock_Flute_11";

    //Phoenix SFX
    public const string PHOENIX_RESPONSE_00 = "Phoenix_Response_00";
    public const string PHOENIX_RESPONSE_01 = "Phoenix_Response_01";
    public const string PHOENIX_RESPONSE_10 = "Phoenix_Response_10";
    public const string PHOENIX_RESPONSE_11 = "Phoenix_Response_11";

    // Ancient Rune SFX
    public const string ANCIENT_RUNE_FLUTE_00 = "Ancient_Rune_Flute_00";
    public const string ANCIENT_RUNE_FLUTE_01 = "Ancient_Rune_Flute_01";
    public const string ANCIENT_RUNE_FLUTE_10 = "Ancient_Rune_Flute_10";
    public const string ANCIENT_RUNE_FLUTE_11 = "Ancient_Rune_Flute_11";
    public const string ANCIENT_RUNE_PUZZLE_SOLVED = "Ancient_Rune_Puzzle_Solved";
    public const string ANCIENT_RUNE_PUZZLE_FAILED = "Ancient_Rune_Puzzle_Failed";
    public const string ANCIENT_RUNE_HUM= "Ancient_Rune_Hum";
    public const string ANCIENT_RUNE_ACTIVATE = "Ancient_Rune_Activate";

    //Misc
    public const string MOVING_SLAB = "Moving_Slab";

    //UI SFX
    public const string UI_SUCCESS = "UI_Success";
}

public class MusicKeys
{
    public const string THEME = "Theme";
    public const string BOSS_1 = "Boss_1";
    public const string ROCKALAVANIA = "Rockalavania";
}
