using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform player;

    [Header("Smooth Follow")]
    [SerializeField] float smoothSpeed = 5f;
    Vector3 velocity = Vector3.zero;

    [Header("Bounds (Corners)")]
    [SerializeField] Transform bottomLeft;
    [SerializeField] Transform topRight;

    [Header("Dead Zone")]
    [SerializeField] float deadZone = 0.5f;

    [SerializeField] bool useBounds = true;

    void LateUpdate()
    {
        // Target position
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);

        // Dead zone logic
        Vector3 delta = player.position - transform.position;

        if (Mathf.Abs(delta.x) < deadZone) targetPos.x = transform.position.x;
        if (Mathf.Abs(delta.y) < deadZone) targetPos.y = transform.position.y;

        // Smooth follow
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 1f / smoothSpeed);

        // Camera size
        float camHeight = Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;

        // Bounds from objects
        float minX = bottomLeft.position.x;
        float maxX = topRight.position.x;
        float minY = bottomLeft.position.y;
        float maxY = topRight.position.y;

        if (useBounds)
        {
            float camX = Mathf.Clamp(smoothPos.x, minX + camWidth, maxX - camWidth);
            float camY = Mathf.Clamp(smoothPos.y, minY + camHeight, maxY - camHeight);

            transform.position = new Vector3(camX, camY, transform.position.z);
        }
        else
        {
            transform.position = smoothPos;
        }
    }
    public void SetBounds(bool enabled)
    {
        useBounds = enabled;
    }
}