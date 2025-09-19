using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    public ObjectivePointer objectivePointer;
    public int index;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        objectivePointer.CompleteObjective(index);
        gameObject.SetActive(false);
    }
}
