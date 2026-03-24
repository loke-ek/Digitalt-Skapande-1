using UnityEngine;
using UnityEngine.InputSystem;

public class PaperPause : MonoBehaviour
{


    public GameObject paperMenu;

    public Movement playerMovement;
    private bool isPaused;


    private void Start()
    {
        paperMenu.SetActive(false);
    }


    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && playerMovement.canOpenPaperGame && !isPaused)
        {
            PauseGame();
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame && isPaused)
        {
            ResumeGame();
        }
    }



    public void PauseGame()
    {
        paperMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        paperMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        Debug.Log("Maya is stupid");
    }
}
