using UnityEngine;

public class WireGameManager : MonoBehaviour
{
    public int wiresSolved;
    public int totalWires = 4;

    public ScreenController screenController;
    public void WireSolved()
    {
        wiresSolved++;

        if (wiresSolved >= totalWires)
        {
            Debug.Log("yayyyy");

            screenController.FixScreen(); // trigger screen change
        }
    }
}