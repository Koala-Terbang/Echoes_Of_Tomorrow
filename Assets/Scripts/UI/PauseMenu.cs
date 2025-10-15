using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject pause;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            openPause();
        }
    }
    public void openPause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void closePause()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
    }
    public void openSettings()
    {
        settings.SetActive(true);
    }
    public void closeSettings()
    {
        settings.SetActive(false);
    }
    public void openMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
