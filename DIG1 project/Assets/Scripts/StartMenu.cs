using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class StartButton : MonoBehaviour
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
        //Application.Quit();
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("DeathScene");
    }
    public void OnExitClick()
    {
#if UNITY_EDITOR
        {
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        
            Application.Quit();
        }
    }
}
