using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    public string levelName;

    [Header("Time")]
    public float threeStarTime = 60f;
    public float twoStarTime = 120f;
    public float oneStarTime = 180f;

    public int CalculateStars(float time)
    {
        if (time <= threeStarTime) return 3;
        if (time <= twoStarTime) return 2;
        if (time <= oneStarTime) return 1;
        return 0;
    }
}