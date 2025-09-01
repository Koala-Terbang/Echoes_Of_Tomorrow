using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoors : MonoBehaviour
{
     public string requiredKeyId;
    public bool consumeKey = true;
    public Animator animator;
    public Collider2D doorBlocker;
    public GameObject doorVisual;
    public GameObject interactUI;

    bool opened;
    bool inside;
    PlayerKeys inv;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || opened) return;
        inside = true;
        inv = other.GetComponent<PlayerKeys>();
        interactUI.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        interactUI.SetActive(false);
        inside = false;
        inv = null;
    }

    void Update()
    {
        if (!inside || opened || inv == null) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool ok = consumeKey ? inv.Use(requiredKeyId) : inv.Has(requiredKeyId);
            if (ok) Open();
        }
    }

    void Open()
    {
        opened = true;
        if (animator) animator.SetBool("Open", true);
        if (doorBlocker) doorBlocker.enabled = false;
        if (doorVisual) doorVisual.SetActive(false);
    }
}
