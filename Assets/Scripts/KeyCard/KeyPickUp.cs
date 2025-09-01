using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public string keyId;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        var inv = other.GetComponent<PlayerKeys>();
        if (!inv) return;
        inv.Add(keyId);
        Destroy(gameObject);
    }
}
