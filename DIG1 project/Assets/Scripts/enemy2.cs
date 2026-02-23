using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveTime = 1f;
    public float waitTime = 1f;

    private Vector2 moveDirection = Vector2.left;
    private float moveTimer;
    private float waitTimer;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        moveTimer = moveTime;
        waitTimer = waitTime;
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        moveDirection = -moveDirection;

        // Flip sprite depending on direction
        spriteRenderer.flipX = moveDirection.x > 0;

        moveTimer = moveTime;
        waitTimer = waitTime;
    }
}
