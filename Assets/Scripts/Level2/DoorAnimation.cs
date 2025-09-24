using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorMechanics : MonoBehaviour
{
    private Animator animator;
    public AudioClip openningSFX;
    private ShadowCaster2D shadowCaster2D;
    int playersInside = 0;

    void Awake()
    {
        animator = GetComponent<Animator>();
        shadowCaster2D = GetComponent<ShadowCaster2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playersInside++;
        if (playersInside == 1)
        {
            SetOpen(true);
            shadowCaster2D.enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playersInside = Mathf.Max(0, playersInside - 1);
        if (playersInside == 0)
        {
            SetOpen(false);
            shadowCaster2D.enabled = true;
        }
    }

    void SetOpen(bool open)
    {
        AudioManager.I.PlaySFX(openningSFX);
        animator.SetBool("Open", open);
    }
}
