using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        [TextArea] public string text;
        public AudioClip audioClip;
    }
    public DialogueLine[] lines;
    public TextMeshProUGUI dialogueText;

    private int currentIndex = 0;

    void Start()
    {
        ShowLine(currentIndex);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            currentIndex++;
            if (currentIndex < lines.Length)
                StartCoroutine(ShowLine(currentIndex));
            else
                EndDialogue();
        }
    }

    IEnumerator ShowLine(int index)
    {
        DialogueLine line = lines[index];
        if (line.audioClip != null)
            // AudioManager.I?.PlaySFX(line.audioClip);

        yield return new WaitForSeconds(0.5f);

        dialogueText.text = line.text;
    }

    void EndDialogue()
    {
        gameObject.SetActive(false);
        currentIndex = 0;
    }
}
