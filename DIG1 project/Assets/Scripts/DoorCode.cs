using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DoorCode : MonoBehaviour
{
    [Header("Code Digits")]
    public int valueOne;
    public int valueTwo;
    public int valueThree;
    public int valueFour;

    // [SerializeField] List<int> entries =);

    public int entryOne;
    public int entryTwo;
    public int entryThree;
    public int entryFour;

    [Header("Posters")]
    [SerializeField] Painting posterOne;
    [SerializeField] Painting posterTwo;
    [SerializeField] Painting posterThree;
    [SerializeField] Painting posterFour;

    [Header("Code Lock")]
    bool inRange;
    bool inLock;
    [SerializeField] TextMeshProUGUI numberDisplay;
    string numberDisplayValue = "";

    [SerializeField] GameObject codeLock;
    

    void Start()
    {
        codeLock.SetActive(false);

        valueOne = Random.Range(0, 10);
        valueTwo = Random.Range(0, 10);
        valueThree = Random.Range(0, 10);
        valueFour = Random.Range(0, 10);
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

    private void CodeProceed()
    {
        if(inRange && inLock && valueOne == entryOne && valueTwo == entryTwo && valueThree == entryThree && valueFour == entryFour)
        {
            //lås upp dörr (ta bort collision och ändra sprite)
        }
    }

}
