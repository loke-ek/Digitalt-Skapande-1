using UnityEngine;
using UnityEngine.EventSystems;

public class WireDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    public RectTransform startPoint;
    public RectTransform wireLine;
    public RectTransform dragPoint;

    public RectTransform correctTarget; // the correct node

    private Vector2 startPos;

    public GameObject lightOn;
    public GameObject lightOff;



    public WireGameManager gameManager;
    private bool connected = false;


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        startPos = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta; // / canvas.scaleFactor;

        UpdateWire();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DetectConnection();
    }

    void UpdateWire()
    {
        Vector2 start = startPoint.position;
        Vector2 end = rectTransform.position;

        
        //Vector2 start = startPoint.anchoredPosition;
        //Vector2 end = rectTransform.anchoredPosition;


        Vector2 dir = end - start;
        float distance = dir.magnitude;

        // Set the position at the start
        wireLine.position = start;

        // Set the length of the wire
        wireLine.sizeDelta = new Vector2(distance, wireLine.sizeDelta.y);

        // Rotate the wire
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        wireLine.rotation = Quaternion.Euler(0, 0, angle);
    }

    void DetectConnection()
    {
        float dist = Vector2.Distance(rectTransform.position, correctTarget.position);

        if (dist < 40f)
        {
            rectTransform.position = correctTarget.position;

            ConnectWire();

            Debug.Log("Wire Connected!");
        }
        else
        {
            rectTransform.anchoredPosition = startPos;
            UpdateWire();
        }
    }

    void ConnectWire()
    {
        if (connected) return;

        connected = true;

        lightOn.SetActive(true);
        lightOff.SetActive(false);

        gameManager.WireSolved();
    }
}