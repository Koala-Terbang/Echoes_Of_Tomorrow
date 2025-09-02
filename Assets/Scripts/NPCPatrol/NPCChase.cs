using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChase : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3.5f;
    public float arrive = 0.2f;
    public Transform[] waypoints;
    public float stuckTime = 3f;
    public float minMovePerSec = 0.1f;
    private Animator animator;
    public string animName;

    Transform player;
    Rigidbody2D rb;
    Vector2 home;
    int wp = 0;
    bool sees = false;
    Vector2 lastSeen;
    bool hasLastSeen = false;

    Vector2 lastPos;
    float stuckTimer = 0f;

    void Awake()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        player = p.transform;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;

        home = transform.position;
        lastPos = transform.position;
    }

    void FixedUpdate()
    {
        Vector2 pos = rb.position;
        bool hasWps = waypoints != null && waypoints.Length > 0;

        Vector2 target;
        float speed;
        ChooseTargetAndSpeed(pos, hasWps, out target, out speed);

        Vector2 to = target - pos;
        float d = to.magnitude;
        Vector2 dir = (d > 0.001f) ? (to / d) : Vector2.zero;
        rb.velocity = dir * speed;

        if (rb.velocity.sqrMagnitude > 0.0001f)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        Vector2 goal = CurrentGoal(hasWps);
        StuckCheck(goal, hasWps);

        lastPos = transform.position;

        if (animator)
        {
            if (rb.velocity.sqrMagnitude > 0.01f)
                animator.Play(animName);
            else
                animator.Play("Idle");
        }
    }

    void ChooseTargetAndSpeed(Vector2 pos, bool hasWps, out Vector2 target, out float speed)
    {
        if (sees && player != null)
        {
            target = player.position;
            speed  = chaseSpeed;
            lastSeen = target;
            hasLastSeen = true;
            return;
        }

        if (hasLastSeen)
        {
            target = lastSeen;
            speed  = patrolSpeed;
            if (Vector2.SqrMagnitude(target - pos) <= arrive * arrive)
                hasLastSeen = false;
            return;
        }

        if (hasWps)
        {
            target = waypoints[wp].position;
            speed  = patrolSpeed;
            if (Vector2.SqrMagnitude(target - pos) <= arrive * arrive)
            {
                wp = (wp + 1) % waypoints.Length;
                target = waypoints[wp].position;
            }
            return;
        }

        target = home;
        speed  = patrolSpeed;
    }

    Vector2 CurrentGoal(bool hasWps)
    {
        if (sees && player != null) return player.position;
        if (hasLastSeen) return lastSeen;
        if (hasWps) return waypoints[wp].position;
        return home;
    }

    void StuckCheck(Vector2 goal, bool hasWps)
    {
        float moved = Vector2.Distance(transform.position, lastPos);
        float movePerSec = moved / Time.fixedDeltaTime;

        float distToGoal = Vector2.Distance(transform.position, goal);
        bool hasGoal = distToGoal > arrive * 1.5f;

        if (hasGoal && movePerSec < minMovePerSec)
        {
            stuckTimer += Time.fixedDeltaTime;
            if (stuckTimer >= stuckTime)
            {
                Vector2 station = hasWps ? (Vector2)waypoints[wp].position : home;
                transform.position = station;
                rb.velocity = Vector2.zero;

                sees = false;
                hasLastSeen = false;

                stuckTimer = 0f;
                lastPos = transform.position;
            }
        }
        else stuckTimer = 0f;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            PlayerMovement pm = other.collider.GetComponent<PlayerMovement>();
            pm.Die();
            rb.velocity = Vector2.zero;
        }
    }

    public void See(Vector2 at)
    {
        sees = true;
        lastSeen = at;
        hasLastSeen = true;
    }

    public void LostSight()
    {
        sees = false;
    }
}
