using UnityEngine;

public class PaperGameManager : MonoBehaviour
{
    public int papersPlaced;
    public int totalPapers = 3;

    [SerializeField] int codeIndex;

    private bool completed = false;

    public void PaperPlacedCorrectly()
    {
        papersPlaced++;

        if (papersPlaced >= totalPapers && !completed)
        {
            completed = true;

            int result = CodeManager.instance.GetDigit(codeIndex);

            Debug.Log("Paper solved! Number is: " + result);

            FindAnyObjectByType<PaperPause>().ResumeGame();
        }
    }
}