using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float walkTime = 3f;
    public float idleTime = 2f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool walkingRight = true;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.flipX = true;  // facing left
        spriteRenderer.flipX = false; // facing right

        StartCoroutine(PatrolRoutine());
    }

    IEnumerator PatrolRoutine()
    {
        while (true)
        {
            // WALK
            animator.SetBool("isWalking", true);
            animator.SetFloat("direction", walkingRight ? 1 : -1);

            spriteRenderer.flipX = !walkingRight;

            float timer = 0;

            while (timer < walkTime)
            {
                float dir = walkingRight ? 1 : -1;
                rb.linearVelocity = new Vector2(dir * walkSpeed, 0);

                timer += Time.deltaTime;
                yield return null;
            }

            rb.linearVelocity = Vector2.zero;

            // IDLE
            animator.SetBool("isWalking", false);

            yield return new WaitForSeconds(idleTime);

            // TURN
            walkingRight = !walkingRight;
        }
    }
}