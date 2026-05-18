using UnityEngine;

public class leveldSetUp : MonoBehaviour
{
    [SerializeField] int codeLength = 4;

    private void Awake()
    {
        CodeManager.instance.GenerateCode(codeLength);
    }
}