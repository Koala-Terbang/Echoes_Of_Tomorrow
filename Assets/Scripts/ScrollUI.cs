using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollUI : MonoBehaviour
{
    public RectTransform root;
    public RectTransform clip;
    public RectTransform paper;
    public TextMeshProUGUI text;
    public float unravelTime = 0.6f;
    public float typeSpeed = 40f;
    public float afterDelay = 0.5f;
    public bool closeOnAnyKey = true;

    float targetHeight;
    Coroutine co;

    void Awake()
    {
        if (root) root.gameObject.SetActive(false);
        if (clip) targetHeight = clip.sizeDelta.y;
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
        if (clip) SetHeight(clip, 0f);

        float t = 0f;
        while (t < unravelTime)
        {
            t += Time.unscaledDeltaTime;
            float h = Mathf.Lerp(0f, targetHeight, t / unravelTime);
            if (clip) SetHeight(clip, h);
            if (paper) SetHeight(paper, h);
            yield return null;
        }
        if (clip) SetHeight(clip, targetHeight);
        if (paper) SetHeight(paper, targetHeight);

        string full = (lines != null && lines.Length > 0) ? string.Join("\n", lines) : "";
        yield return StartCoroutine(TypeText(full));

        yield return new WaitUntil(() => Input.anyKeyDown);
        Hide();
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
            yield return null;
            float delay = 1f / Mathf.Max(1f, typeSpeed);
            float t = 0f;
            while (t < delay)
            {
                t += Time.unscaledDeltaTime;
                yield return null;
            }
        }
    }

    public void Hide()
    {
        if (co != null) StopCoroutine(co);
        co = null;
        if (root) root.gameObject.SetActive(false);
    }

    static void SetHeight(RectTransform rt, float h)
    {
        var s = rt.sizeDelta;
        rt.sizeDelta = new Vector2(s.x, h);
    }
}
