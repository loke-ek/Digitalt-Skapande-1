using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorCode : MonoBehaviour
{
    [Header("Code Digits")]
    public int valueOne;
    public int valueTwo;
    public int valueThree;
    public int valueFour;

    [SerializeField] List<int> entries;

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
            codeLock.SetActive(true);
            inLock = true;
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
