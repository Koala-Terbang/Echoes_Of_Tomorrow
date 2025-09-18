using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesktopUI : MonoBehaviour
{
    public void Dispatch()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
