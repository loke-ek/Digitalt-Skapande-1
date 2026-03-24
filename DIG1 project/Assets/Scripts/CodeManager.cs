using UnityEngine;

public class CodeManager : MonoBehaviour
{
    public static CodeManager instance;

    [Header("Code Digits")]
    public int paintingNumber;
    public int wireNumber;
    public int paperNumber;
    public int randomObjectNumber;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // persist across scenes
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        GenerateCode();
    }

    void GenerateCode()
    {
        paintingNumber = Random.Range(0, 10);
        wireNumber = Random.Range(0, 10);
        paperNumber = Random.Range(0, 10);
        randomObjectNumber = Random.Range(0, 10);

        Debug.Log($"CODE: {paintingNumber}{wireNumber}{paperNumber}{randomObjectNumber}");
    }

    public string GetFullCode()
    {
        return paintingNumber.ToString() +
               wireNumber.ToString() +
               paperNumber.ToString() +
               randomObjectNumber.ToString();


    }
}