using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveTime = 1f;
    public float waitTime = 1f;

    public GameObject characterUp;
    public GameObject characterDown;

    private Vector2 moveDirection = Vector2.up;
    private float moveTimer;
    private float waitTimer;

    void Start()
    {
        moveTimer = moveTime;
        waitTimer = waitTime;

        characterUp.SetActive(true);
        characterDown.SetActive(false);
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

        if (moveDirection.y > 0)
        {
            characterUp.SetActive(true);
            characterDown.SetActive(false);
        }
        else
        {
            characterUp.SetActive(false);
            characterDown.SetActive(true);
        }

        moveTimer = moveTime;
        waitTimer = waitTime;
    }
}