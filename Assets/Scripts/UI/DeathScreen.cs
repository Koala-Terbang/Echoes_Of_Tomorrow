using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject root;
    public Transform respawnPoint1;
    public Transform respawnPoint2;
    public Transform player;
    PlayerMovement pm;

    bool showing;

    void Awake()
    {
        pm = player.GetComponent<PlayerMovement>();
    }
    public void Show()
    {
        if (showing) return;
        showing = true;

        root.SetActive(true);
    }

    public void Hide()
    {
        if (!showing) return;
        showing = false;
        if (root) root.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        Hide();
        if (pm.level2)
            player.position = respawnPoint2.position;
        else
            player.position = respawnPoint1.position;
        Time.timeScale = 1f;
        pm.Respawn();
    }
}
