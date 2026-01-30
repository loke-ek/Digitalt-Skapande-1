using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour
{
    SpriteRenderer playerSr;

    [SerializeField] public float stress;
    [SerializeField] Image stressBar;

    [SerializeField] float sugar;
    [SerializeField] Image sugarBar;

    [SerializeField] public float rechargeRate = 10.0f;

    private void Start()
    {
        playerSr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        stressBar.fillAmount = stress / 100; // uppdaterar stressbar
        sugarBar.fillAmount = sugar / 100; // uppdaterar sugarbar

        if(sugar >= 100)
        {
            StartCoroutine(InvisibilityCor());
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CandyA"))
        {
            sugar += 15;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("CandyB"))
        {
            sugar += 30;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vision") && playerSr.enabled == true)
        {
            Debug.Log("charging");
            stress = Mathf.Min(stress + rechargeRate * Time.deltaTime, 100f);
        }
    }

    IEnumerator InvisibilityCor()
    {
        Debug.Log("started coroutine");
        playerSr.enabled = false;
        yield return new WaitForSeconds(3);
        playerSr.enabled = true;
    }

}
