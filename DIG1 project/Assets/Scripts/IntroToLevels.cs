using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.Timeline.DirectorControlPlayable;

public class IntroToLevels : MonoBehaviour
{
    private bool playerInRange = false;

    public GameObject uiText;

    InputAction interactAction;

    private void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        uiText.SetActive(false);
    }


    void Update()
    {

        if (interactAction.WasPerformedThisFrame() && playerInRange)
        {
            ButtonPress();
        }
        uiText.SetActive(playerInRange);
    }

    private void ButtonPress()
    {
        SceneManager.LoadScene("LevelsOptions");
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
