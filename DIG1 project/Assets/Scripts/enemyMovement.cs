using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveTime = 1f;
    public float waitTime = 1f;
    public BoxCollider2D roamArea;

    public Transform field; 
    public float rotationSpeed = 180f; 

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
            RotateFOV();
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

        if (roamArea.bounds.Contains(newPos))
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
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0: moveDirection = Vector2.up; break;
            case 1: moveDirection = Vector2.down; break;
            case 2: moveDirection = Vector2.left; break;
            case 3: moveDirection = Vector2.right; break;
        }

        moveTimer = moveTime;
        waitTimer = waitTime;
    }

    void RotateFOV()
    {
        if (moveDirection == Vector2.zero) return;


        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90);

        field.rotation = Quaternion.RotateTowards(field.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
