using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausePanel;

    public void Start()
    {
    }

    public void Update()
    {
        
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }


}



