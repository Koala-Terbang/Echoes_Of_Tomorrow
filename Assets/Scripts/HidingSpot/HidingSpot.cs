using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    public Transform hidePoint;
    private Animator animator;
    GameObject occupant;
    public bool CanEnter() => occupant == null;
    public bool HasOccupant => occupant != null;

    void Start()
    {
        hidePoint = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    public void Enter(GameObject player)
    {
        animator.Play("Locker");
        occupant = player;
    }

    public void Exit(GameObject player)
    {
        animator.Play("Locker");
        if (occupant == player) occupant = null;
    }
}
