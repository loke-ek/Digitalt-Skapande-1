using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject optionsPanel;

    public void Start()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Options()
    {
        optionsPanel.SetActive(true);
    }

    public void Back()
    {
        optionsPanel.SetActive(false);
    }
    
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

}



