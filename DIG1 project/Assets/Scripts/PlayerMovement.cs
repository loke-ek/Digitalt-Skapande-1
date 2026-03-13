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

    [Header("Directional Animators")]
    public GameObject animUp;
    public GameObject animDown;
    public GameObject animSide;

    Animator animUpA;
    Animator animDownA;
    Animator animSideA;

    bool canMove = true;
    bool isInvisible = false;

    public bool canOpenPaperGame = false;
    public bool canOpenAmongUs = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        moveAction = InputSystem.actions.FindAction("Move");
        dashAction = InputSystem.actions.FindAction("Jump");

        animUpA = animUp.GetComponent<Animator>();
        animDownA = animDown.GetComponent<Animator>();
        animSideA = animSide.GetComponent<Animator>();

    }

    void Update()
    {
        Debug.Log("Update running");

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
        if (isInvisible) return;

        bool isMoving = moveVector.sqrMagnitude > 0.01f;

        Vector2 dir = isMoving ? moveVector : lastMoveDir;

        bool horizontal = Mathf.Abs(dir.x) > Mathf.Abs(dir.y);

        // Always reset all animators' isMoving bool
        animUpA.SetBool("isMoving", false);
        animDownA.SetBool("isMoving", false);
        animSideA.SetBool("isMoving", false);

        // Hide all SpriteRenderers first
        animUp.GetComponent<SpriteRenderer>().enabled = false;
        animDown.GetComponent<SpriteRenderer>().enabled = false;
        animSide.GetComponent<SpriteRenderer>().enabled = false;

        if (horizontal)
        {
            animSideA.SetBool("isMoving", isMoving);

            SpriteRenderer sr = animSide.GetComponent<SpriteRenderer>();
            sr.flipX = dir.x < 0;
            sr.enabled = true; // Only this direction visible
            
        }
        else
        {
            if (dir.y > 0)
            {
                animUpA.SetBool("isMoving", isMoving);
                animUp.GetComponent<SpriteRenderer>().enabled = true;
                
            }
            else
            {
                animDownA.SetBool("isMoving", isMoving);
                animDown.GetComponent<SpriteRenderer>().enabled = true;
                
            }
        }
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

    public void SetInvisible(bool invisible)
    {
        isInvisible = invisible;

        if (invisible)
        {
            Debug.Log("invisible");
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PaperGame"))
            canOpenPaperGame = true;

        if (other.CompareTag("CandyC"))
            canOpenAmongUs = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PaperGame"))
            canOpenPaperGame = false;

        if (other.CompareTag("CandyC"))
            canOpenAmongUs = false;
    }

    public void PlayFootStep()
    {
        FindAnyObjectByType<AudioManager>().PlaySound(0);
    }

}

