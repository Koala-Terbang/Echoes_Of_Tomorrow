using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    public Animator animator;
    void Reset()
    {
        if (!animator) animator = GetComponentInParent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SetOpen(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        SetOpen(false);
    }

    void SetOpen(bool open)
    {
        if (animator)
            animator.SetBool("Open", open);
    }
}
