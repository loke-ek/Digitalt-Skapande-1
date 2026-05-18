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
        if (playerInRange && interactAction.WasPerformedThisFrame())
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
            FindAnyObjectByType<AudioManager>().PlaySound(6);
            gameObject.SetActive(false);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
