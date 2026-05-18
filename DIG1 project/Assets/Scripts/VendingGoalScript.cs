using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class VendingGoalScript : MonoBehaviour
{
    [Header("MINIGAME")]
    [SerializeField] private float goalPosMin;
    [SerializeField] private float goalPosMax;

    private bool inMinigame;
    private bool gameWon;

    [Header("ANIMATION")]
    [SerializeField] Animator can_below_anim;

    InputAction stopAction;

    [Header("INDICATOR")]
    [SerializeField] GameObject indicator_obj;
    [SerializeField] private float indicatorPosMin;
    [SerializeField] private float indicatorPosMax;
    [SerializeField] private float indicatorSpeed;
    bool indicatorActive = true;

    void Start()
    {
        stopAction = InputSystem.actions.FindAction("Attack");
        NewGoalPosition();
        inMinigame = true;
    }


    void Update()
    {
        ReadStopAction();
        if (indicatorActive)
        {
            float y = Mathf.PingPong(Time.time * indicatorSpeed, 1) * indicatorPosMax - indicatorPosMin;
            indicator_obj.transform.position = new Vector3(indicator_obj.transform.position.x, y, 0);
        }
    }

    void NewGoalPosition()
    {
        float y = Random.Range(goalPosMin, goalPosMax);
        transform.localPosition = new Vector3(transform.localPosition.x, y, 0);
    }

    void ReadStopAction()
    {
        if(inMinigame && stopAction.WasCompletedThisFrame())
        {
            // stoppa pilen och känn igen om målet nuddar den
            Debug.Log("Stop Indicator");
            indicatorActive = false;
            can_below_anim.SetTrigger("Won");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Indicator"))
        {
            Debug.Log("HIT GOAL!!!");
            can_below_anim.SetTrigger("Won");
        }
    }
}
