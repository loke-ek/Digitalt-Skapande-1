using UnityEngine;
using UnityEngine.EventSystems;

public class WireDrag : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public RectTransform wireStart;
    public RectTransform wireLine;
    public RectTransform dragPoint;

    private Canvas canvas;

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragPoint.anchoredPosition += eventData.delta / canvas.scaleFactor;

        UpdateWire();
    }

    void UpdateWire()
    {
        Vector2 dir = dragPoint.anchoredPosition - wireStart.anchoredPosition;

        float distance = dir.magnitude;

        wireLine.sizeDelta = new Vector2(distance, wireLine.sizeDelta.y);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        wireLine.rotation = Quaternion.Euler(0, 0, angle);

        wireLine.anchoredPosition = wireStart.anchoredPosition;
    }
}