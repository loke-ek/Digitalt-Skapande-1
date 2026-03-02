using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Painting : MonoBehaviour
{
    [SerializeField] public Sprite paintingRemoved;
    [SerializeField] public Sprite paintingNormal;

    [SerializeField] bool inRange;
    bool interacted = false;

    [SerializeField] SpriteRenderer painting_sr;

    void Start()
    {
        painting_sr.sprite = paintingNormal;
    }


    void Update()
    {
        if(inRange && !interacted && Keyboard.current.eKey.wasPressedThisFrame)
        {
            painting_sr.sprite = paintingRemoved;
            interacted = true;
        }
        if(inRange && interacted && Keyboard.current.eKey.wasPressedThisFrame)
        {
            painting_sr.sprite = paintingNormal;
            interacted = false;
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
