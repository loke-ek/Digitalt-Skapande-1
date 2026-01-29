using UnityEngine;

public class EnemyField : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveTime = 1f;
    public float waitTime = 1f;

    public Sprite Forward;
    public Sprite Backward;

    private SpriteRenderer sr;

    private Vector2 moveDirection = Vector2.up;
    private float moveTimer;
    private float waitTimer;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Forward;

        moveTimer = moveTime;
        waitTimer = waitTime;
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

        // Change sprite
        if (moveDirection == Vector2.up)
            sr.sprite = Forward;
        else
            sr.sprite = Backward;

        // Reset timers
        moveTimer = moveTime;
        waitTimer = waitTime;
    }
}
