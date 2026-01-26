using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour
{
    [SerializeField] float stress;
    [SerializeField] Image stressBar;
    [SerializeField] float sugar;
    [SerializeField] Image sugarBar;
    float rechargeRate = 10.0f;

    private void Update()
    {
        stressBar.fillAmount = stress / 100; // uppdaterar stressbar
        sugarBar.fillAmount = sugar / 100; // uppdaterar sugarbar
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // inget
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vision"))
        {
            Debug.Log("charging");
            stress = Mathf.Min(stress + rechargeRate * Time.deltaTime, 100f);
        }
        else
        {
            Debug.Log("not touching Vision");
        }
        
    }

}
