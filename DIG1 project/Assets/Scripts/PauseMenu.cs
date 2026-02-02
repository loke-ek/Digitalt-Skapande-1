using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    InputAction pauseAction;

    private bool isPaused;

    public GameObject pausePanel;

    public void Start()
    {
        //so we can press "esc" and make the pause screen appear
        pauseAction = InputSystem.actions.FindAction("Next");

        isPaused = false;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Next"))
        {
            {
                if (isPaused)
                    ResumeGame();
                else 
                    PauseGame();
            }
        }
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel .SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        isPaused = false;
    }

}



