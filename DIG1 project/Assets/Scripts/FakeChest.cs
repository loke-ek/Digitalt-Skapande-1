using UnityEngine;
using UnityEngine.InputSystem;

public class FakeChest : MonoBehaviour
{
    public Sprite Closed;
    public Sprite Open;

    private SpriteRenderer sr;
    private bool isOn = false;
    private bool playerInRange = false;

    //public GameObject uiText;

    public bool IsOn => isOn;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Closed;

    }

    void Update()
    {
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            ToggleChest();

        }

        if (playerInRange)
        {
            //uiText.SetActive(true);

        }
        else
        {
            //uiText.SetActive(false);
        }
    }
    private void ToggleChest()
    {
        isOn = !isOn;
        if (isOn)
        {
            sr.sprite = Open;

        }
        else
        {
            sr.sprite = Closed;
            { 
             
            
            }

        }
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
