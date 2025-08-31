using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject root;

    bool showing;

    public void Show()
    {
        if (showing) return;
        showing = true;

        root.SetActive(true);

        Time.timeScale = 0f;
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
        Time.timeScale = 1f;
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }
}
