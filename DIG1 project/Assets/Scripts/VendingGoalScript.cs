using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class VendingGoalScript : MonoBehaviour
{
    private float goalPosMin = -0.45f;
    private float goalPosMax = 0.45f;

    private bool inMinigame;
    private bool gameWon;

    InputAction stopAction;
    
    void Start()
    {
        stopAction = InputSystem.actions.FindAction("Attack");
        NewGoalPosition();
    }


    void Update()
    {
        
    }

    void NewGoalPosition()
    {
        float randomXValue = Random.Range(goalPosMin, goalPosMax);
    }

    void ReadStopAction()
    {
        if(inMinigame && stopAction.WasCompletedThisFrame())
        {
            // stoppa pilen och känn igen om målet nuddar den
            Debug.Log("Stop Indicator");
        }
    }
    
}
