using UnityEngine;

public class RandomNumber : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] sprites;

    void Start()
    {
        int number = CodeManager.instance.randomObjectNumber;

        sr.sprite = sprites[number];
    }
}
