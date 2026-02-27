using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PauseMenu : MonoBehaviour
{
    InputAction pauseAction;

    public GameObject pauseMenuPanel;
    private bool isPaused;


    private void Start()
    {
        pauseAction = InputSystem.actions.FindAction("Next");
    }


    void Update()
    {
        OnButtonPress();
    }

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


    void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
