using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public NPCChase npc;                // your existing chaser script
    public LayerMask losMask;           // tick Player + Walls in Inspector

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Vector2 from = npc.transform.position;
        Vector2 to   = other.transform.position;

        // First thing between NPC and Player?
        RaycastHit2D hit = Physics2D.Linecast(from, to, losMask);

        if (hit.collider && hit.collider.CompareTag("Player"))
        {
            npc.See(to);                // update + chase
            Debug.DrawLine(from, to, Color.green);
        }
        else
        {
            npc.LostSight();            // blocked by wall → stop seeing
            if (hit.collider) Debug.DrawLine(from, hit.point, Color.red);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) npc.LostSight();
    }
}
