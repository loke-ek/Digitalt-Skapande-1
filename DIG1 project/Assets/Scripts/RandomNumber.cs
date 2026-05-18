using UnityEngine;

public class RandomNumber : MonoBehaviour
{
    [SerializeField] int codeIndex;

    public SpriteRenderer sr;
    public Sprite[] sprites;

    void Start()
    {
        int number = CodeManager.instance.GetDigit(codeIndex);

        sr.sprite = sprites[number];
    }
}
