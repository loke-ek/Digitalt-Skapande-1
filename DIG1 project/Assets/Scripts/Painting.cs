using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Painting : MonoBehaviour
{

    [SerializeField] bool inRange;
    [SerializeField] DoorCode door_s;

    [Header("Sprites")]

    [SerializeField] public int hiddenType;
    [SerializeField] List <Sprite> hiddenSprites;
    [SerializeField] SpriteRenderer hidden_sr;

    [SerializeField] public Sprite coverRemoved;
    [SerializeField] public Sprite coverNormal;
    [SerializeField] SpriteRenderer cover_sr;

    void Start()
    {
        cover_sr.sprite = coverNormal;
        //hiddenType = door_s.valueOne;
        // hiddenType = Random.Range(0, hiddenSprites.Count);

        cover_sr.sprite = coverNormal;

        hiddenType = CodeManager.instance.paintingNumber;

        hidden_sr.sprite = hiddenSprites[hiddenType];
    }


    void Update()
    {
        if(inRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("removes cover");
            cover_sr.sprite = coverRemoved;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }


}
