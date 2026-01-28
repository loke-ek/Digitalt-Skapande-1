using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyableObject : MonoBehaviour
{
    Rigidbody2D objectRb;

    private bool playerInRange;


    //lets us interact with the object
    InputAction interactAction;

    //reference to the circle thing that shows up when we can interact
    public GameObject prompt;
    public GameObject explosionParticles;



    void Start()
    {
        prompt.SetActive(false);

        interactAction = InputSystem.actions.FindAction("Interact");

    }

    private void Update()
    {
        if (playerInRange && interactAction.WasPerformedThisFrame())
        {
            DestroyObject();
        }
    }

  

    //destroys the object and plays explosion particles
    public void DestroyObject()
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(true);
            playerInRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            prompt.SetActive(false);
            playerInRange = false;
        }
    }

}
