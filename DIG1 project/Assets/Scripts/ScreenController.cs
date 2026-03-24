using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public SpriteRenderer screenRenderer;

    [Header("Sprites")]
    public Sprite brokenScreen;
    public Sprite[] randomScreens;

    private bool isFixed = false;

    void Start()
    {
        // Start with broken screen
        screenRenderer.sprite = brokenScreen;
    }

    public void FixScreen()
    {
        if (isFixed) return;

        isFixed = true;

        // Pick random sprite
        int index = Random.Range(0, randomScreens.Length);
        screenRenderer.sprite = randomScreens[index];
    }

    public void ShowNumber(int number)
    {
        if (isFixed) return;

        isFixed = true;

        screenRenderer.sprite = randomScreens[number];

        Debug.Log("Maya is stupid");
    }
}