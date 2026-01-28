using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveTime = 1f;
    public float waitTime = 1f;

    public Sprite Right;
    public Sprite Left;

    private SpriteRenderer sr;

    private Vector2 moveDirection = Vector2.right;
    private float moveTimer;
    private float waitTimer;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Right;

        moveTimer = moveTime;
        waitTimer = waitTime;
    }

    void Update()
    {
        //if timer is gone they start moving
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

        if (moveDirection == Vector2.right)
            sr.sprite = Right;
        else
            sr.sprite = Left;

        moveTimer = moveTime;
        waitTimer = waitTime;
    }
}
