using UnityEngine;
using UnityEngine.InputSystem;

public class DoorOpen : MonoBehaviour
{

    private bool playerInRange;


    //lets us interact with the object
    InputAction interactAction;




    void Start()
    {

        interactAction = InputSystem.actions.FindAction("Interact");

    }

    private void Update()
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        if (playerInRange && interactAction.WasPerformedThisFrame())
        {
            FindAnyObjectByType<AudioManager>().PlaySound(6);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
