using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class IntroToLevels : MonoBehaviour
{
    private bool playerInRange = false;

    public GameObject uiText;

    void Update()
    {

        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            ButtonPress();
        }
        uiText.SetActive(playerInRange);
    }

    private void ButtonPress()
    {
        SceneManager.LoadScene("Levels Options");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

}
