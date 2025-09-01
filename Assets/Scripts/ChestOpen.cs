using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public ScrollUI scrollUI;
    public string[] lines;

    bool playerInside;
    bool opened;
    public GameObject ChestUI;

    void Reset() => GetComponent<Collider2D>().isTrigger = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerInside = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerInside = false;
    }

    void Update()
    {
        if (!playerInside) return;
        if (opened) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            opened = true;
            scrollUI.Show(lines);
            ChestUI.SetActive(true);
        }
    }
}
