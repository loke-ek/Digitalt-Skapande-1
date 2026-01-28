using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyableObject : MonoBehaviour
{
    Rigidbody2D objectRb;

    private bool playerInRange;

    public int objectHp;

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
        
    }

    public void OnTrigger2D(Collider2D other)
    {
        if (playerInRange && interactAction.WasPerformedThisFrame())
        {
            objectHp--;
            if (objectHp <= 0)
            {
                DestroyObject();
            }

        }
    }

    //destroys the object and plays explosion particles
    public void DestroyObject()
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            prompt.SetActive(true);
            playerInRange = true;

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            prompt.SetActive(false);
            playerInRange = false;
        }
    }


}
