using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    InputAction pauseAction;

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public AudioMixer audioMixer;

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

    //for exiting the options menu
    public void ExitOptions()
    {
        optionsMenu.SetActive(false);
    }

    //for loading the options menu
    public void LoadOptions()
    { 
        optionsMenu.SetActive(true);
    }

    //for quitting the game
    public void QuitGame()
    {
        Application.Quit();
    }

    //for pausing the game
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    //for resuming the game
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void SetVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        float dB = Mathf.Log10(volume) * 20;

        audioMixer.SetFloat("volume", dB);
    }


    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
