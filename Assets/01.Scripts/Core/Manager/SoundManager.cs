using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [Header("사운드 등록")]
    [SerializeField] private List<Sound> sfx_sounds = new();

    [SerializeField] private AudioSource BG_Player;
    [SerializeField] private AudioSource SFX_Player;

    private Dictionary<string, AudioClip> play_sounds = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);

        sfx_sounds.ForEach(p => play_sounds.Add(p.soundName, p.clip));
    }
    public void PlayerSoundName(string soundName)
    {
        var clip = play_sounds[soundName];
        SFX_Player.clip = clip;
        SFX_Player.Play();
    }
    public void Set_BG(float value)
    {
        BG_Player.volume = value;
    }
    public void Set_SFX(float value)
    {
        SFX_Player.volume = value;
    }

    internal void PlayerSoundName(object playerSoundName)
    {
        throw new NotImplementedException();
    }
}
