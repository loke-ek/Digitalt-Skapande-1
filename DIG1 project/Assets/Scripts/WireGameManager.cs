using UnityEngine;

public class WireGameManager : MonoBehaviour
{
    public int wiresSolved;
    public int totalWires = 4;

    [SerializeField] int codeIndex;

    public ScreenController screenController;

    public void WireSolved()
    {
        wiresSolved++;

        if (wiresSolved >= totalWires)
        {
            if (screenController == null)
            {
                Debug.LogError("ScreenController missing!");
                return;
            }

            int result = CodeManager.instance.GetDigit(codeIndex);

            screenController.ShowNumber(result);
        }
    }
}