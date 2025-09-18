using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Checker : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        PlayerMovement pm = collision.GetComponent<PlayerMovement>();
        pm.level2 = true;
    }
}
