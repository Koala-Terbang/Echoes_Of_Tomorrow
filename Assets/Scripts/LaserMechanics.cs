using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMechanics : MonoBehaviour
{
    public DeathScreen deathScreen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        deathScreen.Show();
    }
}
