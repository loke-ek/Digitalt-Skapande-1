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
