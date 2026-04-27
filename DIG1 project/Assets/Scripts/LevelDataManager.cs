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
        Debug.Log("LevelDataManager created: " + gameObject.GetInstanceID());
    }

    public void SaveStars(string levelName, int stars)
    {
        int current = PlayerPrefs.GetInt(levelName, 0);

        if (stars > current)
        {
            PlayerPrefs.SetInt(levelName, stars);
        }
        Debug.Log("SAVE " + levelName + " = " + stars + " (previous: " + current + ")");
    }

    public int GetStars(string levelName)
    {
        int stars = PlayerPrefs.GetInt(levelName, 0);

        Debug.Log("LOAD " + levelName + " = " + stars);

        return stars;
    }
}