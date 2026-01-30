using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour
{
    SpriteRenderer playerSr;

    [SerializeField] public float stress;
    [SerializeField] public Image stressBar;

    [SerializeField] public float sugar;
    [SerializeField] public Image sugarBar;

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
            // FindAnyObjectByType<AudioManager>().PlaySound(2);
            StartCoroutine(InvisibilityCor());
            sugar = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CandyA"))
        {
            // FindAnyObjectByType<AudioManager>().PlaySound(1);
            sugar += 15;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("CandyB"))
        {
            // FindAnyObjectByType<AudioManager>().PlaySound(1);
            CandyB();
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vision") && playerSr.enabled == true)
        {
            // FindAnyObjectByType<AudioManager>().PlaySound(4);
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

    public void CandyB()
    {
        sugar += 30;
    }

}
