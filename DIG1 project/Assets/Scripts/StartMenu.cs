using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void OnWinClick()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quits game");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("DeathScene");
    }
    
    public void LoadPrevious()
    {
        if(PlayerPrefs.GetInt("LastPlayedLevel", 1) == 1)
        {
            SceneManager.LoadScene("Office");
        }

        //if (PlayerPrefs.GetInt("LastPlayedLevel", 1) == 2)
        {
            // SceneManager.LoadScene("[LEVEL 2 HÄR]");
        }

        //if (PlayerPrefs.GetInt("LastPlayedLevel", 1) == 3)
        {
            // SceneManager.LoadScene("[LEVEL 3 HÄR]"); etc etc etc...
        }
    }
}
