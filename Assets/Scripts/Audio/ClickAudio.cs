using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAudio : MonoBehaviour
{
    public AudioClip clickSound;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.I.PlaySFX(clickSound);
        }
    }
}
