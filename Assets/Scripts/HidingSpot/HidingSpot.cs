using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    public Transform hidePoint;
    // public string openTrigger = "Open";
    // public string closeTrigger = "Close";
    GameObject occupant;
    public bool CanEnter() => occupant == null;
    public bool HasOccupant => occupant != null;

    void Start()
    {
        hidePoint = GetComponent<Transform>();
    }

    public void Enter(GameObject player)
    {
        occupant = player;
        // if (animator && !string.IsNullOrEmpty(openTrigger)) animator.SetTrigger(openTrigger);
    }

    public void Exit(GameObject player)
    {
        if (occupant == player) occupant = null;
        // if (animator && !string.IsNullOrEmpty(closeTrigger)) animator.SetTrigger(closeTrigger);
    }
}
