using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMechanics : MonoBehaviour
{
    public NPCChase[] responders;
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
        Vector2 from = transform.position;
        Vector2 to   = other.transform.position;

        RaycastHit2D hit = Physics2D.Linecast(from, to, losMask);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            for (int i = 0; i < responders.Length; i++)
                if (responders[i]) responders[i].See(to);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        for (int i = 0; i < responders.Length; i++)
            if (responders[i]) responders[i].LostSight();
    }
}
