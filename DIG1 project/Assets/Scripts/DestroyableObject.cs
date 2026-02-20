using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyableObject : MonoBehaviour
{
    Rigidbody2D objectRb;

    private bool playerInRange;


    //lets us interact with the object
    InputAction interactAction;




    void Start()
    {

        interactAction = InputSystem.actions.FindAction("Interact");

    }

    private void Update()
    {
        ObjectDisappear();
    }

    public void ObjectDisappear()
    {
        if (playerInRange && interactAction.WasPerformedThisFrame())
        {
            FindAnyObjectByType<AudioManager>().PlaySound(6);
            DestroyObject();
        }
    }

    //destroys the object and plays explosion particles
    public void DestroyObject()
    {
        Destroy(gameObject);
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
