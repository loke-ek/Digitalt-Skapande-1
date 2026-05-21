using UnityEngine;

public class leveldSetUp : MonoBehaviour
{
    [SerializeField] int codeLength = 4;

    private void Awake()
    {
        if (CodeManager.instance != null)
        {
            CodeManager.instance.GenerateCode(codeLength);
        }
        else
        {
            Debug.LogError("CodeManager missing!");
        }
    }
}