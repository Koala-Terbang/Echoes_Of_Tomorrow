using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChase : MonoBehaviour
{
    [Header("Refs")]
    public Transform player;               // drag Player
    public PlayerStealth playerStealth;  // drag PlayerStealth2D

    [Header("Speeds")]
    public float runSpeed  = 3f;           // while chasing
    public float walkSpeed = 2f;           // returning home

    [Header("Home")]
    public float stopHomeDistance = 0.05f; // snap when close

    Rigidbody2D rb;
    Vector2 home;
    bool alerted; // latched: stays true until player hides

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        home = transform.position;

        // Fix spinning:
        rb.gravityScale = 0f;                                // top-down
        rb.constraints   = RigidbodyConstraints2D.FreezeRotation; // prevent torque spin
        // (Optional) rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void FixedUpdate()
    {
        // If player is hidden, stop chasing (drop alert)
        if (playerStealth && playerStealth.IsHidden) alerted = false;

        Vector2 pos = rb.position;
        Vector2 target;
        float speed;

        if (alerted && player) {              // keep chasing until hidden
            target = (Vector2)player.position;
            speed  = runSpeed;
        } else {                              // go home
            target = home;
            speed  = walkSpeed;
        }

        Vector2 dir  = target - pos;
        float  dist = dir.magnitude;

        if (!alerted && dist <= stopHomeDistance)
        {
            rb.velocity = Vector2.zero;
            rb.MovePosition(home);            // snap to exact home
            return;
        }

        dir = (dist > 0.001f) ? dir / dist : Vector2.zero;
        rb.velocity = dir * speed;

        // Optional: face movement by flipping sprite
        var sr = GetComponentInChildren<SpriteRenderer>();
        if (sr && Mathf.Abs(rb.velocity.x) > 0.01f) sr.flipX = rb.velocity.x < 0f;
    }

    // Called by the vision cone when the player enters it
    public void Alert() => alerted = true;

    // Optional: call this if you want to force calm from other scripts
    public void CalmDown() => alerted = false;
}
