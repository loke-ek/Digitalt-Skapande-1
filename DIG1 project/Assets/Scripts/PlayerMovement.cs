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

    [SerializeField] CameraScript cam;

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
    public bool isInvisible { get; private set; }

    public bool canOpenPaperGame = false;
    public bool canOpenAmongUs = false;

    AudioManager audioManager;

    bool isInCutscene = false;
    [SerializeField] float cutsceneSpeed = 2f;

    bool isIntroWalking = false;
    [SerializeField] Vector2 winWalkDirection = Vector2.left;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        moveAction = InputSystem.actions.FindAction("Move");
        dashAction = InputSystem.actions.FindAction("Jump");

        animUpA = animUp.GetComponent<Animator>();
        animDownA = animDown.GetComponent<Animator>();
        animSideA = animSide.GetComponent<Animator>();

        audioManager = FindAnyObjectByType<AudioManager>();
    }
    void Update()
    {
        if (isInCutscene)
        {
            ForceWalk();
            return;
        }

        if (isIntroWalking)
        {
            ForceWalkDown();
            return;
        }

        if (!canMove) return;

        ReadPlayerMoveInput();
        UpdateVisuals();
    }
    void FixedUpdate()
    {
        if (isInCutscene)
        {
            playerRb.linearVelocity = winWalkDirection.normalized * cutsceneSpeed;
            return;
        }

        if (isIntroWalking)
        {
            playerRb.linearVelocity = Vector2.down * cutsceneSpeed;
            return;
        }

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

    public void PlayFootstep()
    {

        audioManager.PlaySound(0);
        

    }
    public void StartWinWalk()
    {
        cam.SetBounds(false);
        isInCutscene = true;
        canMove = false; // just for safety
    }
    void ForceWalk()
    {
        animUpA.SetBool("isMoving", false);
        animDownA.SetBool("isMoving", false);
        animSideA.SetBool("isMoving", false);

        animUp.GetComponent<SpriteRenderer>().enabled = false;
        animDown.GetComponent<SpriteRenderer>().enabled = false;
        animSide.GetComponent<SpriteRenderer>().enabled = false;

        // Horizontal movement
        if (Mathf.Abs(winWalkDirection.x) > Mathf.Abs(winWalkDirection.y))
        {
            animSideA.SetBool("isMoving", true);

            SpriteRenderer sr = animSide.GetComponent<SpriteRenderer>();

            // flip when walking left
            sr.flipX = winWalkDirection.x < 0;

            sr.enabled = true;
        }
        else
        {
            // Vertical movement
            if (winWalkDirection.y > 0)
            {
                animUpA.SetBool("isMoving", true);
                animUp.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                animDownA.SetBool("isMoving", true);
                animDown.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    void ForceWalkDown()
    {
        animUpA.SetBool("isMoving", false);
        animDownA.SetBool("isMoving", false);
        animSideA.SetBool("isMoving", false);

        animUp.GetComponent<SpriteRenderer>().enabled = false;
        animDown.GetComponent<SpriteRenderer>().enabled = false;
        animSide.GetComponent<SpriteRenderer>().enabled = false;

        animDownA.SetBool("isMoving", true);
        animDown.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void StartIntroWalkDown()
    {
        isIntroWalking = true;
        canMove = false;
    }

    public void EndIntroWalk()
    {
        isIntroWalking = false;
        canMove = true;
    }

}

