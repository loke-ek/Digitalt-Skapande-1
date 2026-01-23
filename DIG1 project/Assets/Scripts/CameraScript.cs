using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    Vector3 offset;

    void Start()
    {
        offset= transform.position - playerPosition.position;
    }

    
    void Update()
    {
        transform.position = playerPosition.position + offset;
    }
}
