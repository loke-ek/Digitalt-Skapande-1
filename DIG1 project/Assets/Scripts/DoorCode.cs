using UnityEngine;

public class DoorCode : MonoBehaviour
{
    [Header("Code Digits")]
    public int valueOne;
    public int valueTwo;
    public int valueThree;
    public int valueFour;

    [Header("Posters")]
    [SerializeField] Painting posterOne;
    [SerializeField] Painting posterTwo;
    [SerializeField] Painting posterThree;
    [SerializeField] Painting posterFour;

    void Start()
    {
        valueOne = Random.Range(0, 10);
        valueTwo = Random.Range(0, 10);
        valueThree = Random.Range(0, 10);
        valueFour = Random.Range(0, 10);
    }



}
