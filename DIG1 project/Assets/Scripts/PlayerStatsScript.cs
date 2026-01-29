using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour
{
    [SerializeField] float stress;
    [SerializeField] Image stressBar;

    [SerializeField] float sugar;
    [SerializeField] Image sugarBar;

    [SerializeField] float rechargeRate = 10.0f;

    [SerializeField] GameObject candyA;
    [SerializeField] GameObject candyB;
    private PickupCandyA pickupCandyA_s;


    private void Start()
    {
        pickupCandyA_s = candyA.GetComponent<PickupCandyA>();
    }
    private void Update()
    {
        stressBar.fillAmount = stress / 100; // uppdaterar stressbar
        sugarBar.fillAmount = sugar / 100; // uppdaterar sugarbar
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            Debug.Log("Pick up candy");
            // sugar += (lägger till candyValue:n som den typen av candy);
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("No candy found");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vision"))
        {
            Debug.Log("charging");
            stress = Mathf.Min(stress + rechargeRate * Time.deltaTime, 100f);
        }
    }

}
