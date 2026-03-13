using UnityEngine;

public class WireGameManager : MonoBehaviour
{
    public int wiresSolved;
    public int totalWires = 4;

    public GameObject hiddenNumber;

    public void WireSolved()
    {
        wiresSolved++;

        if (wiresSolved >= totalWires)
        {
            hiddenNumber.SetActive(true);
        }
    }
}