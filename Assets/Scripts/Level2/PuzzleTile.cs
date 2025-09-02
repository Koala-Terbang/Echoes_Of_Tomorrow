using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTile : MonoBehaviour
{
    public bool isCorrect;
    public Transform respawnPoint;
    public SpriteRenderer highlight;
    public float shownAlpha = 0.9f;
    public float holdTime = 1.0f;
    public float fadeTime = 0.3f;
    private Transform tile;
    public NPCChase[] responders;
    public AudioClip falseTileSFX;
    private Coroutine co;

    private void Awake()
    {
        if (highlight) SetAlpha(0f);
        tile = GetComponent<Transform>();
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

        if (!isCorrect && respawnPoint != null)
        {
            AudioManager.I.PlaySFX(falseTileSFX);
            var rb = other.attachedRigidbody;
            rb.position = respawnPoint.position;
        }
        else if (!isCorrect && responders != null)
        {
            for (int i = 0; i < responders.Length; i++)
                if (responders[i]) responders[i].See(tile.position);
        }
    }
}
