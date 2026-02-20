using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class StartMenu : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("Office");
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
    
}
