using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public NPCChase npc;
    public LayerMask losMask;
    private SpriteRenderer sr;
    Coroutine hideRoutine;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        HideImmediate();
    }

    public void Reveal()
    {
        sr.enabled = true;

        if (hideRoutine != null) StopCoroutine(hideRoutine);
        hideRoutine = StartCoroutine(HideAfterDelay());
    }

    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        HideImmediate();
    }

    void HideImmediate()
    {
        if (sr) sr.enabled = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Vector2 from = npc.transform.position;
        Vector2 to   = other.transform.position;

        RaycastHit2D hit = Physics2D.Linecast(from, to, losMask);

        if (hit.collider && hit.collider.CompareTag("Player"))
        {
            npc.See(to);
            Debug.DrawLine(from, to, Color.green);
        }
        else
        {
            npc.LostSight();
            if (hit.collider) Debug.DrawLine(from, hit.point, Color.red);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) npc.LostSight();
    }
}
