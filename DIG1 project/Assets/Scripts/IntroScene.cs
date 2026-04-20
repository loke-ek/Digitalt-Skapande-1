using System.Collections;
using UnityEngine;

public class IntroScene : MonoBehaviour
{
    [SerializeField] GameObject candybarText;
    [SerializeField] GameObject stressbarText;
    [SerializeField] GameObject candybartextFull;

    [SerializeField] GameObject playerStats;


    void Start()
    {
        playerStats.GetComponent<PlayerStatsScript>();

        if (candybarText.activeInHierarchy)
        {
            StartCoroutine(HideIntroText());
        }

        if (playerStats.GetComponent<PlayerStatsScript>().sugar == 50)
        {
            StartCoroutine(FullCandyBar());
        }
    }

    void Update()
    {

    }

    IEnumerator HideIntroText()
    {
        yield return new WaitForSeconds(10);
        candybarText.SetActive(false);
        stressbarText.SetActive(false);
    }

    IEnumerator FullCandyBar()
    {
        yield return new WaitForSeconds(10);
        candybarText.SetActive(true);
    }

}
