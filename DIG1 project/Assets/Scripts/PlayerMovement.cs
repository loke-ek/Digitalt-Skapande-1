using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody2D playerRb;

    InputAction moveAction;
    InputAction dashAction;
    Vector2 moveVector;

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed;

    [Header("Dash Settings")]
    [SerializeField] float dashSpeed;
    [SerializeField] bool isDashing;

    [Header("Sprites")]
    public Sprite Forward;
    public Sprite Backward;
    public Sprite Left;
    public Sprite Right;
    Vector2 lastMoveDir = Vector2.down; // default facing forward
    SpriteRenderer PlayerSR;

    AudioManager audioManager;

    [Header("Stun mecanic")]
    bool canMove = true;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        PlayerSR = GetComponent<SpriteRenderer>();
        //audioManager = FindAnyObjectByType<AudioManager>();

        moveAction = InputSystem.actions.FindAction("Move");
        dashAction = InputSystem.actions.FindAction("Jump");
    }

    
    void Update()
    {
        if (!canMove) return;

        ReadPlayerMoveInput();
        SpriteChange();
    }

    private void FixedUpdate()
    {
        if (!canMove) return;
        MovePlayer();       
    }


    void ReadPlayerMoveInput()
    {
        // movement
        {
            moveVector = moveAction.ReadValue<Vector2>();
        }

        // dashing
        if (dashAction.WasPerformedThisFrame())
        {
            StartCoroutine(Dashcor());
        }
        //makes it stay in the right sprite when it stops mvoing
        lastMoveDir = moveVector;
    }

    void MovePlayer()
    { 
        
        // dashing 
        if (isDashing)
        {
            playerRb.linearVelocity = moveVector * dashSpeed;
        }
        else
        {
            playerRb.linearVelocity = moveVector * moveSpeed;
        }
    }

    IEnumerator Dashcor()
    {
        //dashing cooldown
        isDashing = true;
        yield return new WaitForSeconds(0.1f);
        isDashing = false;

        yield return new WaitForSeconds(2f);
    }

    void SpriteChange()
    {
        Vector2 dir = moveVector != Vector2.zero ? moveVector : lastMoveDir;

        // Horizontal movement has priority
        if (Mathf.Abs(moveVector.x) > Mathf.Abs(moveVector.y))
        {
            if (moveVector.x > 0)
                PlayerSR.sprite = Right;
            else
                PlayerSR.sprite = Left;
        }
        else
        {
            if (moveVector.y > 0)
                PlayerSR.sprite = Backward; // up
            else
                PlayerSR.sprite = Forward;  // down
        }
    }

    public void PlayFootStep()
    {
        audioManager.PlaySound(0);
    }
    public void Freeze()
    {
        canMove = false;
        playerRb.linearVelocity = Vector2.zero;
    }

    public void Unfreeze()
    {
        canMove = true;
    }


}
