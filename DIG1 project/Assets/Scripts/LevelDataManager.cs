using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    public static LevelDataManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveStars(string levelName, int stars)
    {
        int current = PlayerPrefs.GetInt(levelName, 0);

        if (stars > current)
        {
            PlayerPrefs.SetInt(levelName, stars);
        }
    }

    public int GetStars(string levelName)
    {
        return PlayerPrefs.GetInt(levelName, 0);
    }
}