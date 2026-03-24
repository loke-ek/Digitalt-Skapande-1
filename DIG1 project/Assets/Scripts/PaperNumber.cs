using UnityEngine;
using UnityEngine.UI;

public class PaperNumber : MonoBehaviour
{
    public Image img;           // UI Image component
    public Sprite[] numberSprites; // Sprites 0–9

    void Start()
    {
        int number = CodeManager.instance.paperNumber;

        // Assign the correct sprite based on code number
        img.sprite = numberSprites[number];

        Debug.Log("Maya is stupid");
    }
}
