using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;

public class Chest : MonoBehaviour
{
    public Sprite Closed;
    public Sprite Open;

    private SpriteRenderer sr;
    private bool playerInRange = false;
    private bool hasOpened = false;

    public GameObject uiText;
    private PlayerStatsScript sugar;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Closed;
    }

    void Update()
    {
        if (playerInRange && !hasOpened && Keyboard.current.eKey.wasPressedThisFrame)
        {
            OpenChest();
            FindAnyObjectByType<AudioManager>().PlaySound(3);
        }

        uiText.SetActive(playerInRange && !hasOpened);
    }

    private void OpenChest()
    {
        hasOpened = true;
        sr.sprite = Open;

        if (sugar != null)
        {
            sugar.CandyB();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sugar = collision.GetComponent<PlayerStatsScript>();
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
