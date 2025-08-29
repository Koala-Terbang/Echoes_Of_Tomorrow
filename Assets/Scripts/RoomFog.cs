using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFog : MonoBehaviour
{
    private SpriteRenderer fog;
    public float hiddenAlpha = 0.9f;
    private float shownAlpha  = 0.0f;
    public float fadeInTime  = 0.15f;
    public float fadeOutTime = 0.25f;

    private Coroutine fadeRoutine;
    private void Awake()
    {
        if (!fog) fog = GetComponent<SpriteRenderer>();
        SetAlpha(hiddenAlpha);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        StartFade(shownAlpha, fadeInTime);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        StartFade(hiddenAlpha, fadeOutTime);
    }

    private void StartFade(float target, float time)
    {
        if (fadeRoutine != null) StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(FadeTo(target, time));
    }

    IEnumerator FadeTo(float targetAlpha, float duration)
    {
        Color c = fog.color;
        float start = c.a;
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float a = Mathf.Lerp(start, targetAlpha, t / duration);
            fog.color = new Color(c.r, c.g, c.b, a);
            yield return null;
        }
        fog.color = new Color(c.r, c.g, c.b, targetAlpha);
        fadeRoutine = null;
    }

    private void SetAlpha(float a)
    {
        var c = fog.color;
        fog.color = new Color(c.r, c.g, c.b, a);
    }
}
