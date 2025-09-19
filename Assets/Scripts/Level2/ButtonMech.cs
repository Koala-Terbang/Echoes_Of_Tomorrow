using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ButtonMech : MonoBehaviour
{
    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera bpCam;
    public GameObject wall;
    private bool playerInside = false;
    private bool used = false;
    private float animationTime = 2.5f;
    public GameObject CoreCharge;
    public string animationName;
    private Animator anim;
    public GameObject interactPrompt;
    public CoreChaging core;
    private PlayerMovement pm;
    public AudioClip ChargeSFX;
    public ObjectivePointer objectivePointer;
    public int index;

    void Awake()
    {
        anim = CoreCharge.GetComponent<Animator>();
    }
    void Update()
    {
        if (playerInside && !used && Input.GetKeyDown(KeyCode.E))
        {
            used = true;
            interactPrompt.SetActive(false);
            StartCoroutine(SwitchCam());
            objectivePointer.CompleteObjective(index);
            core.charges++;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pm = other.GetComponent<PlayerMovement>();
            if (interactPrompt && !used) interactPrompt.SetActive(true);
            playerInside = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(interactPrompt && !used) interactPrompt.SetActive(false);
            playerInside = false;
        }
    }

    private IEnumerator SwitchCam()
    {
        pm.enabled = false;
        mainCam.Priority = 5;
        bpCam.Priority = 10;
        yield return new WaitForSeconds(2f);
        if (wall) wall.SetActive(false);
        AudioManager.I.PlaySFX(ChargeSFX);
        anim.Play(animationName);
        yield return new WaitForSeconds(animationTime);
        mainCam.Priority = 10;
        bpCam.Priority = 5;
        yield return new WaitForSeconds(2f);
        pm.enabled = true;
    }
}
