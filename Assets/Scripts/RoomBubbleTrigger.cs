using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBubbleTrigger : MonoBehaviour
{
    public DialogBubble bubble; 
    public string[] lines;
    public float duration = 3f;
    public bool showOnce = true;

    bool shown;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (showOnce && shown) return;

        bubble.ShowLines(lines, duration);
        shown = true;
    }
}
