using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Checker : MonoBehaviour
{
    public GameObject checkPoint;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        PlayerMovement pm = collision.GetComponent<PlayerMovement>();
        if (!pm.level2)
        {
            StartCoroutine(ShowCheck());
        }
        pm.level2 = true;
    }
    IEnumerator ShowCheck()
    {
        checkPoint.SetActive(true);
        yield return new WaitForSeconds(1);
        checkPoint.SetActive(false);
    }
}
