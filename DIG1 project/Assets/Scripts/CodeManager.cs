using System.Collections.Generic;
using UnityEngine;

public class CodeManager : MonoBehaviour
{
    public static CodeManager instance;

    public List<int> currentCode = new List<int>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void GenerateCode(int length)
    {
        currentCode.Clear();

        for (int i = 0; i < length; i++)
        {
            currentCode.Add(Random.Range(0, 10));
        }

        Debug.Log("Generated Code: " + GetFullCode());
    }

    public int GetDigit(int index)
    {
        if (index < 0 || index >= currentCode.Count)
        {
            Debug.LogError("Invalid code index!");
            return 0;
        }

        return currentCode[index];
    }

    public string GetFullCode()
    {
        string result = "";

        foreach (int digit in currentCode)
        {
            result += digit.ToString();
        }

        return result;
    }
}