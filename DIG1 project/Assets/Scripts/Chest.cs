using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    public Sprite Closed;
    public Sprite Open;

    private SpriteRenderer sr;
    private bool isOn = false;
    private bool playerInRange = false;

    public GameObject uiText;

    public bool IsOn => isOn;

    private bool hasOpened;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Closed;

    }

    void Update()
    {
        if (playerInRange && !hasOpened && Keyboard.current.eKey.wasPressedThisFrame)
        {
            ToggleChest();

        }

        if (playerInRange && !hasOpened)
        {
            uiText.SetActive(true);

        }
        else
        {
            uiText.SetActive(false);
        }
    }
    private void ToggleChest()
    {
        isOn = !isOn;
        hasOpened = true;
        if (isOn)
        {
            sr.sprite = Open;

        }
        else
        {
            sr.sprite = Closed;

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
