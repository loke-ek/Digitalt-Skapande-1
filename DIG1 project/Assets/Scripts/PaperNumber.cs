using UnityEngine;
using UnityEngine.UI;

public class PaperNumber : MonoBehaviour
{
    public Image img;           // UI Image component
    public Sprite[] numberSprites; // Sprites 0–9

    void Start()
    {
        // Wait until CodeManager.instance exists
        if (CodeManager.instance == null)
        {
            Debug.LogError("CodeManager missing!");
            return;
        }

        int number = CodeManager.instance.paperNumber;
        img.sprite = numberSprites[number];
    }
}
