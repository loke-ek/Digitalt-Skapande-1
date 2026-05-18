using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Painting : MonoBehaviour
{
    [SerializeField] bool inRange;

    [SerializeField] int codeIndex;

    [Header("Sprites")]
    [SerializeField] List<Sprite> hiddenSprites;
    [SerializeField] SpriteRenderer hidden_sr;

    [SerializeField] Sprite coverRemoved;
    [SerializeField] Sprite coverNormal;
    [SerializeField] SpriteRenderer cover_sr;

    void Start()
    {
        cover_sr.sprite = coverNormal;

        int number = CodeManager.instance.GetDigit(codeIndex);

        hidden_sr.sprite = hiddenSprites[number];
    }

    void Update()
    {
        if (inRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            cover_sr.sprite = coverRemoved;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}