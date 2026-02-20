using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class StartMenu : MonoBehaviour
{
    [SerializeField] PlayerStatsScript playerStatsScript_s;

    private void Update()
    {
        if(playerStatsScript_s.stress >= 100)
        {
            LoadGameOver();
        }
    }
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
