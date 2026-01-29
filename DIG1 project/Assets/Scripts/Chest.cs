using UnityEngine;

public class Chest : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inventory tempInventory = collision.gameObject.GetComponent<inventory>();

            if (tempInventory.Keys > 0)
            {
                tempInventory.Keys--;
                //tempInventory.KeyText.text = "x" + tempInventory.Keys.ToString();
                Debug.Log("You opened chest");
            }
        }
    }
}
