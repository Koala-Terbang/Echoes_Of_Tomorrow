using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public DeathScreen deathScreen;
    public PCMinigame pc;

    Rigidbody2D rb;
    Vector2 movement;
    Vector2 lastDir = Vector2.down;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        if (movement.sqrMagnitude > 0.1f)
            lastDir = movement;

        if (animator)
        {
            if (movement.sqrMagnitude > 0.1f)
                animator.Play("Moving");
            else
                animator.Play("Idle");
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (lastDir.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(lastDir.y, lastDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
    public void Die()
    {
        StartCoroutine(PlayerDeath());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Goal")) return;

        if (pc == null) pc = FindObjectOfType<PCMinigame>();
        if (pc != null) pc.finished = true;

    SceneManager.UnloadSceneAsync("PCMinigame");
    }
    IEnumerator PlayerDeath()
    {
        rb.velocity = Vector2.zero;
        this.enabled = false;
        animator.Play("DeathAnim");
        yield return new WaitForSeconds(1.3f);   
        if(deathScreen != null)deathScreen.Show();    
    }
}
