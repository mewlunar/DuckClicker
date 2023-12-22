using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioSource music;

    void Start()
    {
        MusicButton.OnMusicStateChanged += SwitchMusicActivities;
    }
    
    void OnDisable()
    {
        MusicButton.OnMusicStateChanged -= SwitchMusicActivities;
    }

    private void SwitchMusicActivities(bool state = true)
    {
        music.mute = !state;
    }
}
