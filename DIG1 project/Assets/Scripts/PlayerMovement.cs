using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody2D playerRb;

    InputAction moveAction;
    InputAction dashAction;

    Vector2 moveVector;
    Vector2 lastMoveDir = Vector2.down;

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 5f;

    [Header("Dash Settings")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] bool isDashing;

    [Header("Idle Sprites")]
    public Sprite Forward;
    public Sprite Backward;
    public Sprite Left;
    public Sprite Right;

    [Header("Idle Renderer (on main player)")]
    public SpriteRenderer idleRenderer;

    [Header("Directional Animators")]
    public GameObject animUp;
    public GameObject animDown;
    public GameObject animLeft;
    public GameObject animRight;

    bool canMove = true;
    bool isInvisible = false;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        moveAction = InputSystem.actions.FindAction("Move");
        dashAction = InputSystem.actions.FindAction("Jump");

        // If you forgot to assign it manually
        if (idleRenderer == null)
            idleRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!canMove) return;

        ReadPlayerMoveInput();
        UpdateVisuals();
    }

    void FixedUpdate()
    {
        if (!canMove) return;

        MovePlayer();
    }

    void ReadPlayerMoveInput()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        // ONLY update lastMoveDir if actually moving
        if (moveVector != Vector2.zero)
            lastMoveDir = moveVector;

        if (dashAction.WasPerformedThisFrame())
            StartCoroutine(Dashcor());
    }

    void MovePlayer()
    {
        float speed = isDashing ? dashSpeed : moveSpeed;
        playerRb.linearVelocity = moveVector * speed;
    }

    IEnumerator Dashcor()
    {
        isDashing = true;
        yield return new WaitForSeconds(0.1f);
        isDashing = false;
    }

    void UpdateVisuals()
    {
        bool isMoving = moveVector != Vector2.zero;

        if (isInvisible) return;

        // Use move direction if moving, otherwise last direction
        Vector2 dir = isMoving ? moveVector : lastMoveDir;

        // Pick direction (horizontal priority)
        bool horizontal = Mathf.Abs(dir.x) > Mathf.Abs(dir.y);

        if (isMoving)
        {
            // Hide idle sprite when moving
            idleRenderer.enabled = false;

            // Enable only one animation object
            if (horizontal)
            {
                if (dir.x > 0) EnableOnly(animRight);
                else EnableOnly(animLeft);
            }
            else
            {
                if (dir.y > 0) EnableOnly(animUp);
                else EnableOnly(animDown);
            }
        }
        else
        {
            // Not moving: disable all animators and show idle sprite
            DisableAllAnimObjects();
            idleRenderer.enabled = true;

            if (horizontal)
            {
                idleRenderer.sprite = dir.x > 0 ? Right : Left;
            }
            else
            {
                idleRenderer.sprite = dir.y > 0 ? Backward : Forward;
            }
        }
    }

    void EnableOnly(GameObject obj)
    {
        animUp.SetActive(obj == animUp);
        animDown.SetActive(obj == animDown);
        animLeft.SetActive(obj == animLeft);
        animRight.SetActive(obj == animRight);
    }

    void DisableAllAnimObjects()
    {
        animUp.SetActive(false);
        animDown.SetActive(false);
        animLeft.SetActive(false);
        animRight.SetActive(false);
    }

    public void Freeze()
    {
        canMove = false;
        playerRb.linearVelocity = Vector2.zero;
        DisableAllAnimObjects();
        idleRenderer.enabled = true;
    }

    public void Unfreeze()
    {
        canMove = true;
    }

    public void SetInvisible(bool invisible)
    {
        isInvisible = invisible;

        if (invisible)
        {
            idleRenderer.enabled = false;
            DisableAllAnimObjects();
        }
    }

}

