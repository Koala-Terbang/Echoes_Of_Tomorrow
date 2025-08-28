using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronePatrol : MonoBehaviour
{
    public float revealDuration = 2f;
    public SpriteRenderer srCone;

    SpriteRenderer sr;
    Coroutine hideRoutine;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        HideImmediate();
    }

    public void Reveal()
    {
        sr.enabled = true;
        srCone.enabled = true;

        if (hideRoutine != null) StopCoroutine(hideRoutine);
        hideRoutine = StartCoroutine(HideAfterDelay());
    }

    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(revealDuration);
        HideImmediate();
    }

    void HideImmediate()
    {
        if (sr) sr.enabled = false;
        srCone.enabled = false;
    }
}
