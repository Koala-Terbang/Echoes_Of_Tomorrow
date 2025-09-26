using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMissionTrig : MonoBehaviour
{
    public GameObject sideMission;
    public bool open;
    bool once = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (!once && open)
        {
            sideMission.SetActive(true);
            once = true;
        }
        else if(!open)
            sideMission.SetActive(false);
    }
}
