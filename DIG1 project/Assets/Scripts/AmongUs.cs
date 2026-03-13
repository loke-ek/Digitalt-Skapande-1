using UnityEngine;
using UnityEngine.InputSystem;

public class AmongUs : MonoBehaviour
{
    public GameObject AmongUsM;

    public Movement playerMovement;
    private bool isPaused;


    private void Start()
    {
        AmongUsM.SetActive(false);
    }


    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && playerMovement.canOpenAmongUs && !isPaused)
        {
            PauseGame();
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame && isPaused)
        {
            ResumeGame();
        }
    }



    public void PauseGame()
    {
        AmongUsM.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        AmongUsM.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
