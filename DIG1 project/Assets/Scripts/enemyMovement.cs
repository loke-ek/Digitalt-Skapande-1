using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    Rigidbody2D enemyRb;

    public float moveSpeed = 2f;
    public float moveTime = 1f;
    public float waitTime = 1f;

    public BoxCollider2D cage;

    private Vector2 moveDirection;
    private float moveTimer;
    private float waitTimer;

    void Start()
    {
        ChooseNewDirection();
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
                ChooseNewDirection();
            }
        }
    }

    void Move()
    {
        Vector3 newPos = transform.position + (Vector3)moveDirection * moveSpeed * Time.deltaTime;

        if (cage.bounds.Contains(newPos))
        {
            transform.position = newPos;
        }
        else
        {
            ChooseNewDirection();
        }
    }

    void ChooseNewDirection()
    {
        int random = Random.Range(0, 4);

        switch (random)
        {
            case 0: moveDirection = Vector2.up; break;
            case 1: moveDirection = Vector2.down; break;
            case 2: moveDirection = Vector2.left; break;
            case 3: moveDirection = Vector2.right; break;
        }

        FaceDirection(moveDirection);

        moveTimer = moveTime;
        waitTimer = waitTime;
    }

    void FaceDirection(Vector2 dir)
    {
        if (dir == Vector2.left)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (dir == Vector2.right)
            transform.localScale = new Vector3(1, 1, 1);
    }
}
