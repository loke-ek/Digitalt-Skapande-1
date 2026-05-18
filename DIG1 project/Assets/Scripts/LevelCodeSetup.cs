using UnityEngine;

public class LevelCodeSetup : MonoBehaviour
{
    [SerializeField] int codeLength = 4;

    private void Start()
    {
        CodeManager.instance.GenerateCode(codeLength);
    }
}