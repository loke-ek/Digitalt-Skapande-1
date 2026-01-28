using UnityEngine;

public class KeyCard : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inventory tempInventory = collision.gameObject.GetComponent<inventory>();  //istället för att kolla i inventory scriptet varje gång ås har vi en temorär kallelse till det

            if (tempInventory.KeyCards > 0)
            {
                tempInventory.KeyCards--;
                //tempInventory.KeyCardText.text = "x" + tempInventory.KeyCards.ToString();
                Debug.Log("You unlocked teh door");
            }
        }
    }
}
