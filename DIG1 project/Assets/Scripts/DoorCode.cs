using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

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

        // The door code is randomly chosen
        //valueOne = Random.Range(0, 10);
        //valueTwo = Random.Range(0, 10);
        //valueThree = Random.Range(0, 10);
        //valueFour = Random.Range(0, 10);

        // Door code is added and converted to a string in order to be compared to the code you entered
        //codeValues = valueOne.ToString() + valueTwo.ToString() + valueThree.ToString() + valueFour.ToString();

        codeValues = CodeManager.instance.GetFullCode();
    }

    private void Update()
    {

        if (inRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("open code lock");
            codeLock.SetActive(true);
            inLock = true;
        }

        if(numberDisplay.textInfo.characterCount > 4)
        {
            CodeReset();
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

    public void CodeProceed() // Compare if the numbers you entered are correct once proceed is pressed
    {
        if(inRange && inLock && codeValues == numberDisplayValue) 
        {
            doorCollider.enabled = false;
            doorSr.enabled = false;
            codeLock.SetActive(false);
        }
        if(inRange && inLock && codeValues != numberDisplayValue)
        {
            CodeReset();
        }
    }

    public void CodeReset() // Resets the numbers you entered
    {
        if (inRange && inLock )
        {
            numberDisplayValue = "";
            numberDisplay.text = numberDisplayValue;
        }
    }
}
