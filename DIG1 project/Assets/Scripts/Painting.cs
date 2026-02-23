using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Painting : MonoBehaviour
{
    [SerializeField] public Sprite paintingRemoved;
    [SerializeField] public Sprite paintingNormal;

    SpriteRenderer painting_sr;

    void Start()
    {
        painting_sr = GetComponent<SpriteRenderer>();
        painting_sr.sprite = paintingNormal;
    }


    void Update()
    {
        //em
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // om går in i spelaren gör in range till true
    }


}
