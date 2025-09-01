using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScanCDUI : MonoBehaviour
{
    public Image fill;
    public TMP_Text label;

    float timeLeft;
    float duration;
    bool cooling;

    public bool Ready => !cooling;

    public void Begin(float seconds)
    {
        duration = Mathf.Max(0.0001f, seconds);
        timeLeft = duration;
        cooling = true;
        gameObject.SetActive(true);
    }

    public void ResetReady()
    {
        cooling = false;
        timeLeft = 0f;
        if (fill)  fill.fillAmount = 1f;
        if (label) label.text = "READY";
    }

    void Awake()
    {
        ResetReady();
    }

    void Update()
    {
        if (!cooling)
        {
            if (fill)  fill.fillAmount = 1f;
            if (label) label.text = "READY";
            return;
        }

        timeLeft -= Time.unscaledDeltaTime;
        float p = Mathf.Clamp01(1f - (timeLeft / duration));
        if (fill)  fill.fillAmount = p;
        if (label) label.text = Mathf.CeilToInt(Mathf.Max(0f, timeLeft)).ToString();

        if (timeLeft <= 0f) cooling = false;
    }
}
