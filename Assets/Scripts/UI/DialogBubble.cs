using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBubble : MonoBehaviour
{
    public TMP_Text text;

    Coroutine routine;
    public Animator animator;

    void Awake()
    {
        gameObject.SetActive(false);
        animator.enabled = false;
    }

    public void ShowLines(string[] lines, float lineDuration)
    {
        if (routine != null) StopCoroutine(routine);
        gameObject.SetActive(true);
        routine = StartCoroutine(ShowRoutine(lines, lineDuration));
    }

    IEnumerator ShowRoutine(string[] lines, float lineDuration)
    {
        animator.enabled = true;
        foreach (var line in lines)
        {
            text.text = line;
            yield return new WaitForSeconds(lineDuration);
        }
        Hide();
    }

    public void Hide()
    {
        if (routine != null) StopCoroutine(routine);
        animator.enabled = false;
        routine = null;
        gameObject.SetActive(false);
    }
}
