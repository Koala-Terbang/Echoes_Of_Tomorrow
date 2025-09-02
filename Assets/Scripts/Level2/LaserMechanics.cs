using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMechanics : MonoBehaviour
{
    public AudioClip burnedSFX;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerMovement pm = other.GetComponent<PlayerMovement>();
        AudioManager.I.PlaySFX(burnedSFX);
        pm.Die();
    }   
}
