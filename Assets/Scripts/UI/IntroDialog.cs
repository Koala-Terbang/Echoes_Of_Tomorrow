using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroDialog : MonoBehaviour
{
    [System.Serializable]
    public class DialogueLine
    {
        [TextArea] public string text;
        public Sprite backgroundSprite;
    }
    public DialogueLine[] lines;
    public Image backgroundImage;
    public TextMeshProUGUI dialogueText;
    public GameObject PCZoom;
    public string nextScene;
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

        yield return new WaitForSeconds(0.5f);
        backgroundImage.sprite = line.backgroundSprite;
        dialogueText.text = line.text;
    }

    void EndDialogue()
    {
        gameObject.SetActive(false);
        currentIndex = 0;

        if (nextScene == "null")
        {
            PCZoom.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
