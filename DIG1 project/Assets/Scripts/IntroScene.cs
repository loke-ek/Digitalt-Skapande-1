using System.Collections;
using UnityEngine;

public class IntroScene : MonoBehaviour
{
    [SerializeField] GameObject candybarText;
    [SerializeField] GameObject stressbarText;


    void Start()
    {
        if (candybarText.activeInHierarchy)
        {
            StartCoroutine(HideText());
        }
    }

void Update()
    {
        
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(10);
        candybarText.SetActive(false);
        stressbarText.SetActive(false);
    }
}
