using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public ScrollUI scrollUI;
    public string[] lines;

    bool playerInside;
    bool opened;
    public GameObject interactUI;
    public GameObject ChestUI;
    public string[] AiLine;
    public DialogBubble bubble;
    public AudioClip openingSFX;
    public PlayerMovement pm;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !opened)
        {
            playerInside = true;
            interactUI.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            interactUI.SetActive(false);
        }
    }

    void Update()
    {
        if (!playerInside) return;
        if (opened) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.I.PlaySFX(openingSFX);
            pm.enabled = false;
            if (bubble != null) bubble.ShowLines(AiLine, 3f);
            opened = true;
            scrollUI.Show(lines);
            ChestUI.SetActive(true);
        }
    }
}
