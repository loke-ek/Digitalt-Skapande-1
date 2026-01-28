using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody2D playerRb;

    InputAction moveAction;
    InputAction dashAction;
    InputAction interactAction;
    Vector2 moveVector;

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed;

    [Header("Dash Settings")]
    [SerializeField] float dashSpeed;
    [SerializeField] bool isDashing;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        dashAction = InputSystem.actions.FindAction("Jump");
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    
    void Update()
    {
        ReadPlayerMoveInput();
    }

    private void FixedUpdate()
    {
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

}
