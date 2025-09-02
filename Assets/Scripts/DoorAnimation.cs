using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    private Animator animator;
    public AudioClip openningSFX;
    int playersInside = 0;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playersInside++;
        if (playersInside == 1) SetOpen(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playersInside = Mathf.Max(0, playersInside - 1);
        if (playersInside == 0) SetOpen(false);
    }

    void SetOpen(bool open)
    {
        AudioManager.I.PlaySFX(openningSFX);
        animator.SetBool("Open", open);
    }
}
