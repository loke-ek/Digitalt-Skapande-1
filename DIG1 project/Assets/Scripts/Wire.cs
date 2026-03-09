using UnityEngine;

public class Wire : MonoBehaviour
{
    public SpriteRenderer wireEnd;
    Vector3 startPoint;
    void Start()
    {
        startPoint = transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        transform.position = newPosition;

        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        float dist = Vector3.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2 (dist, wireEnd.size.y);
    }
}
