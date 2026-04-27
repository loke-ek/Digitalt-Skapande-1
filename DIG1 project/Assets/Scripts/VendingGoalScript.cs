using Unity.VisualScripting;
using UnityEngine;

public class VendingGoalScript : MonoBehaviour
{
    private float goalPosMin = -0.45f;
    private float goalPosMax = 0.45f;

    private bool inMinigame;
    private bool gameWon;
    
    void Start()
    {
        NewGoalPosition();

    }


    void Update()
    {
        
    }

    void NewGoalPosition()
    {
        float randomXValue = Random.Range(goalPosMin, goalPosMax);
    }

    
}
