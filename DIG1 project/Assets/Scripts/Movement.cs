using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Rigidbody2D playerRb;

    InputAction moveInput;
    Vector2 moveVector;

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        moveInput = InputSystem.actions.FindAction("Move");
    }

    
    void Update()
    {
        MovePlayer();
    }

    private void FixedUpdate()
    {
        playerRb.linearVelocity = moveVector * moveSpeed;
    }

    void MovePlayer()
    { 
        moveVector = moveInput.ReadValue<Vector2>();
    }

}
