using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ButtonMech : MonoBehaviour
{
    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera bpCam;
    public GameObject wall;
    private bool oneTime = true;
    private bool playerInside = false;
    private bool used = false;
    private float animationTime = 2.5f;
    public GameObject CoreCharge;
    public string animationName;
    private Animator anim;

    void Awake()
    {
        anim = CoreCharge.GetComponent<Animator>();
    }
    void Update()
    {
        if (playerInside && !used && Input.GetKeyDown(KeyCode.E))
        {
            if (wall)
            {
                StartCoroutine(SwitchCam());
            }
            if (oneTime) used = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }

    private IEnumerator SwitchCam()
    {
        mainCam.Priority = 5;
        bpCam.Priority = 10;
        yield return new WaitForSeconds(1f);
        wall.SetActive(false);
        anim.Play(animationName);
        yield return new WaitForSeconds(animationTime);
        mainCam.Priority = 10;
        bpCam.Priority = 5;
    }
}
