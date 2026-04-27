using UnityEngine;
using UnityEngine.UI;

public class LevelButtonUI : MonoBehaviour
{
    public string levelName;

    public Image star1;
    public Image star2;
    public Image star3;

    public Sprite filledStar;
    public Sprite emptyStar;



    void Start()
    {
        
        if (LevelDataManager.instance == null)
        {
            Debug.LogError("LevelDataManager missing in scene!");
            return;
        }

        int stars = LevelDataManager.instance.GetStars(levelName);
        Debug.Log("Loading level: " + levelName + " stars: " + stars);

        star1.sprite = stars >= 1 ? filledStar : emptyStar;
        star2.sprite = stars >= 2 ? filledStar : emptyStar;
        star3.sprite = stars >= 3 ? filledStar : emptyStar;

    }
}