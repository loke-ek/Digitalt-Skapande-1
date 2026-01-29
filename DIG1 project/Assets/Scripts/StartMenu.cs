using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class StartButton : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("Office");
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
