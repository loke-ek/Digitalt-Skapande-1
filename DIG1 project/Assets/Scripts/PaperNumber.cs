using UnityEngine;
using UnityEngine.UI;

public class PaperNumber : MonoBehaviour
{
    [SerializeField] int codeIndex;

    public Image img;
    public Sprite[] numberSprites;

    void Start()
    {
        int number = CodeManager.instance.GetDigit(codeIndex);

        img.sprite = numberSprites[number];
    }
}