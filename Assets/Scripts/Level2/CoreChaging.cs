using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CoreChaging : MonoBehaviour
{
    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera bpCam;
    public GameObject interactUI;
    private Animator anim;
    public int charges;
    private bool inside;
    private bool used;
    private PlayerMovement pm;
    public ObjectivePointer objectivePointer;
    public int index;
    void Awake()
    {
        anim = GetComponent<Animator>();
        charges = 0;
        used = false;
        inside = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inside && !used)
        {
            interactUI.SetActive(false);
            StartCoroutine(SwitchCam());
            objectivePointer.CompleteObjective(index);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && charges >= 3)
        {
            pm = collision.GetComponent<PlayerMovement>();
            inside = true;
            interactUI.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inside = false;
            interactUI.SetActive(false);
        }
    }
    private IEnumerator SwitchCam()
    {
        pm.enabled = false;
        used = true;
        mainCam.Priority = 5;
        bpCam.Priority = 10;
        yield return new WaitForSeconds(2f);
        anim.Play("FinishCharging");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("OutroDialog");
    }
}
