using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMechanics : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerMovement pm = other.GetComponent<PlayerMovement>();
        pm.Die();
    }   
}
