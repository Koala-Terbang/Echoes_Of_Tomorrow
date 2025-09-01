using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioClip Music;
    void Start()
    {
        AudioManager.I.PlayMusic(Music);
    }
}
