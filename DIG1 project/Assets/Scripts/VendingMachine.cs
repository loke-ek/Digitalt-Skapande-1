using UnityEngine;
using UnityEngine.InputSystem;

public class VendingMachine : MonoBehaviour
{
    [SerializeField] GameObject vendingCanvasObj;
    [SerializeField] VendingGoalScript goalScript;
    public bool inRange;
    public bool inMinigame;

    private void Start()
    {
        inMinigame = false;
        vendingCanvasObj.SetActive(false);
    }
    private void Update()
    {
        if (inRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            inMinigame = true;
            vendingCanvasObj.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
            inMinigame = false;
            vendingCanvasObj.SetActive(false);
        }
    }
}
