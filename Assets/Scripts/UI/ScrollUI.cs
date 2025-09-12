using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollUI : MonoBehaviour
{
    public RectTransform root;
    public RectTransform clip;
    public TextMeshProUGUI text;

    public float widenTime = 0.6f;
    public float typeSpeed = 40f;

    public PlayerMovement pm;

    float targetWidth;
    float targetHeight;
    Coroutine co;

    void Awake()
    {
        if (root) root.gameObject.SetActive(false);
        if (clip)
        {
            targetWidth = clip.sizeDelta.x;
            targetHeight = clip.sizeDelta.y;
        }
    }

    public void Show(string[] lines)
    {
        if (co != null) StopCoroutine(co);
        co = StartCoroutine(ShowRoutine(lines));
    }

    IEnumerator ShowRoutine(string[] lines)
    {
        if (!root) yield break;
        root.gameObject.SetActive(true);
        if (text) text.text = "";

        SetSize(clip, 0f, targetHeight);

        float t = 0f;
        while (t < widenTime)
        {
            t += Time.unscaledDeltaTime;
            float w = Mathf.Lerp(0f, targetWidth, t / widenTime);
            SetSize(clip, w, targetHeight);
            yield return null;
        }
        SetSize(clip, targetWidth, targetHeight);

        string full = (lines != null && lines.Length > 0) ? string.Join("\n", lines) : "";
        yield return StartCoroutine(TypeText(full));

        yield return new WaitUntil(() => Input.anyKeyDown);
        Hide();
        pm.enabled = true;
        co = null;
    }

    IEnumerator TypeText(string full)
    {
        if (!text) yield break;
        text.text = "";
        int i = 0;
        while (i < full.Length)
        {
            i++;
            text.text = full.Substring(0, i);
            yield return new WaitForSecondsRealtime(1f / Mathf.Max(1f, typeSpeed));
        }
    }

    public void Hide()
    {
        if (co != null) StopCoroutine(co);
        co = null;
        if (root) root.gameObject.SetActive(false);
    }

    static void SetSize(RectTransform rt, float w, float h)
    {
        var s = rt.sizeDelta;
        rt.sizeDelta = new Vector2(w, h);
    }
}
