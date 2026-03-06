using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PauseMenu : MonoBehaviour
{
    InputAction pauseAction;

    public GameObject pauseMenu;
    public GameObject optionsMenu;

    private bool isPaused;


    private void Start()
    {
        pauseAction = InputSystem.actions.FindAction("Next");

        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);

    }


    void Update()
    {
        OnButtonPress();


    }


    //lets you pause and unpause by pressing esc
    public void OnButtonPress()
    {
        if (pauseAction.WasPerformedThisFrame() && isPaused == false)
        {
            PauseGame();
        }
        else if (pauseAction.WasPerformedThisFrame() && isPaused == true)
        {
            ResumeGame();
        }
    }

    public void ExitOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void LoadOptions()
    { 
        optionsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
