using UnityEngine;

public class PaperGameManager : MonoBehaviour
{
    public int papersPlaced;
    public int totalPapers = 3;

    private bool completed = false;

    public void PaperPlacedCorrectly()
    {
        papersPlaced++;

        if (papersPlaced >= totalPapers && !completed)
        {
            completed = true;

            int result = CodeManager.instance.paperNumber;

            Debug.Log("Paper solved! Number is: " + result);

            FindAnyObjectByType<PaperPause>().ResumeGame();

            Debug.Log("Maya is stupid");
        }
    }
}