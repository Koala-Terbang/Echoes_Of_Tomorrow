using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMechanics : MonoBehaviour
{
    public NPCChase[] responders;
    public LayerMask losMask;

    void Reset()
    {
        var trig = GetComponent<Collider2D>();
        if (trig) trig.isTrigger = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Vector2 from = transform.position;
        Vector2 to   = other.transform.position;

        RaycastHit2D hit = Physics2D.Linecast(from, to, losMask);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            for (int i = 0; i < responders.Length; i++)
                if (responders[i]) responders[i].See(to);

            Debug.DrawLine(from, to, Color.green);
        }
        else
        {
            for (int i = 0; i < responders.Length; i++)
                if (responders[i]) responders[i].LostSight();

            if (hit.collider) Debug.DrawLine(from, hit.point, Color.red);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        for (int i = 0; i < responders.Length; i++)
            if (responders[i]) responders[i].LostSight();
    }
}
