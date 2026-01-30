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
    public Image candyPic;          // UI Image (from Canvas)
    private PlayerStatsScript sugar;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Closed;

        if (candyPic != null)
            candyPic.gameObject.SetActive(false);
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

        Candy();
        StartCoroutine(ShowCandyPic());
    }

    private IEnumerator ShowCandyPic()
    {
        candyPic.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        candyPic.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange = false;
    }

    private void Candy()
    {
        sugar.sugar += 30;
    }
    
}
