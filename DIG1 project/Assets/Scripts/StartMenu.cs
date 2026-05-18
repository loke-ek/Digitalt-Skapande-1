using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    void Start()
    {

    }
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
        string lastScene = PlayerPrefs.GetString("LastPlayedScene", "Office");

        SceneManager.LoadScene(lastScene);
    }
}
