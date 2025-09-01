using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PCMinigame : MonoBehaviour
{
    private bool inside = false;
    public GameObject interactUI;
    public PlayerMovement pm;
    public PlayerScan ps;
    public bool finished = false;
    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera bpCam;
    public Animator anim;
    bool oneTime = false;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !finished)
        {
            interactUI.SetActive(true);
            inside = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !finished)
        {
            interactUI.SetActive(false);
            inside = false;
        }
    }
    private IEnumerator SwitchCam()
    {
        mainCam.Priority = 5;
        bpCam.Priority = 10;
        yield return new WaitForSeconds(2f);
        anim.Play("PurpleCoreCharge");
        yield return new WaitForSeconds(2.5f);
        mainCam.Priority = 10;
        bpCam.Priority = 5;
        yield return new WaitForSeconds(2f);
        pm.enabled = true;
        ps.enabled = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inside && !finished)
        {
            ps.enabled = false;
            pm.enabled = false;
            interactUI.SetActive(false);
            SceneManager.LoadScene("PCMinigame", LoadSceneMode.Additive);
        }
        if (finished && !oneTime)
        {
            StartCoroutine(SwitchCam());
            oneTime = true;
        }
        
    }
}
