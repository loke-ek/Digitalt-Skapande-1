using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DoorCode : MonoBehaviour
{
    SpriteRenderer doorSr;
    BoxCollider2D doorCollider;

    [Header("Code Digits")]
    public int valueOne;
    public int valueTwo;
    public int valueThree;
    public int valueFour;
    [SerializeField] string codeValues;

    [Header("Code Lock")]
    bool inRange;
    bool inLock;
    [SerializeField] TextMeshProUGUI numberDisplay;
    string numberDisplayValue = "";
    [SerializeField] GameObject codeLock;
    

    void Start()
    {
        doorSr = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<BoxCollider2D>();

        doorSr.enabled = true;
        doorCollider.enabled = true;
        codeLock.SetActive(false);

        valueOne = Random.Range(0, 10);
        valueTwo = Random.Range(0, 10);
        valueThree = Random.Range(0, 10);
        valueFour = Random.Range(0, 10);

        codeValues = valueOne.ToString() + valueTwo.ToString() + valueThree.ToString() + valueFour.ToString();
    }

    private void Update()
    {

        if (inRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("open code lock");
            codeLock.SetActive(true);
            inLock = true;
        }
    }

    public void AddDigit(string digit)
    {
        numberDisplayValue += digit;
        numberDisplay.text = numberDisplayValue;
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
            codeLock.SetActive(false);
        }
    }

    public void CodeProceed()
    {
        if(inRange && inLock && codeValues == numberDisplayValue)
        {
            doorCollider.enabled = false;
            doorSr.enabled = false;
            codeLock.SetActive(false);
        }
    }

}
