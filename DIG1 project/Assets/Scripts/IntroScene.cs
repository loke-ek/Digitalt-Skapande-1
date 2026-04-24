using System.Collections;
using UnityEngine;

public class IntroScene : MonoBehaviour
{
    [SerializeField] GameObject candybarText;
    [SerializeField] GameObject stressbarText;
    [SerializeField] GameObject candybartextFull;
    [SerializeField] GameObject timerText;

    [SerializeField] GameObject invisibleWall;

    void Start()
    {
        StartCoroutine(InvisibleWall());
        StartCoroutine(IntroText());
        


    }

    void Update()
    {

    }

    IEnumerator IntroText()
    {
        yield return new WaitForSeconds(5);
        candybarText.SetActive(false);
        stressbarText.SetActive(false);

        yield return new WaitForSeconds(0);
        candybartextFull.SetActive(true);
        yield return new WaitForSeconds(6);
        candybartextFull.SetActive(false);

        yield return new WaitForSeconds(0);
        timerText.SetActive(true);
        yield return new WaitForSeconds(6);
        timerText.SetActive(false);

    }

    IEnumerator InvisibleWall()
    {
        yield return new WaitForSeconds(17);
        invisibleWall.SetActive(false);
    }
  

}
