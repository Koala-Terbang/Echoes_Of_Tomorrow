using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTile : MonoBehaviour
{
    public bool isCorrect;
    public SpriteRenderer highlight;
    public float shownAlpha = 0.9f;
    public float holdTime = 1.0f;
    public float fadeTime = 0.3f;
    public AudioClip falseTileSFX;
    private Coroutine co;

    private void Awake()
    {
        if (highlight) SetAlpha(0f);
    }
    public void Reveal()
    {
        if (!isCorrect || !highlight) return;
        if (co != null) StopCoroutine(co);
        co = StartCoroutine(RevealRoutine());
    }

    private IEnumerator RevealRoutine()
    {
        SetAlpha(shownAlpha);

        if (holdTime > 0f)
            yield return new WaitForSeconds(holdTime);

        if (fadeTime <= 0f) { SetAlpha(0f); co = null; yield break; }

        float t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            SetAlpha(Mathf.Lerp(shownAlpha, 0f, t / fadeTime));
            yield return null;
        }
        SetAlpha(0f);
        co = null;
    }

    private void SetAlpha(float a)
    {
        var c = highlight.color;
        highlight.color = new Color(c.r, c.g, c.b, a);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (!isCorrect)
        {
            AudioManager.I.PlaySFX(falseTileSFX);
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            pm.Die();
        }
    }
}
