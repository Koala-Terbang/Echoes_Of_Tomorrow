using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public NPCChase chaser;      // parent NPC script
    public PlayerStealth playerStealth;   // player stealth flag (assign in Inspector)

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (playerStealth && playerStealth.IsHidden) { chaser.CalmDown(); return; } // ignore/cancel if hidden
        chaser.Alert();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (playerStealth && playerStealth.IsHidden) chaser.CalmDown(); // hide while inside cone → cancel
    }
}
