using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScanCDUI : MonoBehaviour
{
    public TMP_Text label;
    public GameObject panel;

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

    void Awake()
    {
        cooling = false;
        timeLeft = 0f;
        label.text = "READY";
        panel.SetActive(false);
    }

    void Update()
    {
        if (!cooling)
        {
            if (label) label.text = "READY";
            panel.SetActive(false);
            return;
        }
        else if (cooling)
        {
            panel.SetActive(true);
        }

        timeLeft -= Time.unscaledDeltaTime;
        float p = Mathf.Clamp01(1f - (timeLeft / duration));
        if (label) label.text = Mathf.CeilToInt(Mathf.Max(0f, timeLeft)).ToString();

        if (timeLeft <= 0f) cooling = false;
    }
}
