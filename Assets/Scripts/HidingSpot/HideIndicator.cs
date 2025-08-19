using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIndicator : MonoBehaviour
{
    public PlayerMovement movementScript;
    private CircleCollider2D playerCollider;
    public Renderer[] renderersToHide;
    private float snapSpeed = 20f;
    public GameObject interactPrompt;
    HidingSpot nearbySpot;
    HidingSpot currentSpot;
    private PlayerStealth stealth;
    bool isHidden;
    bool isSnapping;

    void Start()
    {
        ShowPrompt(false);
        playerCollider = GetComponent<CircleCollider2D>();
        stealth = GetComponent<PlayerStealth>();
    }

    void Update()
    {
        ShowPrompt(!isHidden && nearbySpot && nearbySpot.CanEnter());

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isHidden && nearbySpot && nearbySpot.CanEnter())
                EnterSpot(nearbySpot);
            else if (isHidden && currentSpot)
                ExitSpot(currentSpot);
        }

        if (isSnapping && isHidden && currentSpot && currentSpot.hidePoint)
        {
            Vector3 target = currentSpot.hidePoint.position;
            transform.position = Vector3.MoveTowards(transform.position, target, snapSpeed * Time.deltaTime);

            if (Vector2.Distance((Vector2)transform.position, (Vector2)target) < 0.01f)
            {
                isSnapping = false;
            }
        }
    }

    void EnterSpot(HidingSpot spot)
    {
        movementScript.enabled = false;
        playerCollider.enabled = false;

        foreach (var r in renderersToHide) if (r) r.enabled = false;

        spot.Enter(gameObject);
        currentSpot = spot;
        stealth.SetHidden(true);
        isHidden = true;
        isSnapping = true;

        ShowPrompt(false);
    }

    void ExitSpot(HidingSpot spot)
    {
        movementScript.enabled = true;
        playerCollider.enabled = true;

        foreach (var r in renderersToHide) if (r) r.enabled = true;

        spot.Exit(gameObject);
        currentSpot = null;
        stealth.SetHidden(false);
        isHidden = false;
        isSnapping = false;
    }

    void ShowPrompt(bool show)
    {
        if (interactPrompt) interactPrompt.SetActive(show);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var spot = other.GetComponentInParent<HidingSpot>();
        if (spot) nearbySpot = spot;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var spot = other.GetComponentInParent<HidingSpot>();
        if (spot && spot == nearbySpot) nearbySpot = null;
    }
}
