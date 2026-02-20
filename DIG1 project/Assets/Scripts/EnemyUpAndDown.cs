using UnityEngine;

public class EnemyUpAndDown : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveTime = 1f;
    public float waitTime = 1f;

    public Animator animatorUp;
    public Animator animatorDown;

    private Vector2 moveDirection = Vector2.up;
    private float moveTimer;
    private float waitTimer;

    void Start()
    {
        moveTimer = moveTime;
        waitTimer = waitTime;

        // Start moving up
        animatorUp.enabled = true;
        animatorDown.enabled = false;
    }

    void Update()
    {
        if (moveTimer > 0)
        {
            Move();
            moveTimer -= Time.deltaTime;
        }
        else
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0)
            {
                TurnAround();
            }
        }
    }

    void Move()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void TurnAround()
    {
        // Flip direction
        moveDirection = -moveDirection;

        // Switch animators
        if (moveDirection.y > 0)
        {
            animatorUp.enabled = true;
            animatorDown.enabled = false;
        }
        else
        {
            animatorUp.enabled = false;
            animatorDown.enabled = true;
        }

        // Reset timers
        moveTimer = moveTime;
        waitTimer = waitTime;
    }
}