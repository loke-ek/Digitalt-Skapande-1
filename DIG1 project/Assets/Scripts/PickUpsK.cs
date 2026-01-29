using UnityEngine;

public class PickUpsK : MonoBehaviour
{
    AudioManager audioManager;

    public void Start()
    {
        FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayKeyPickup();
            Destroy(gameObject);
        }
    }

    public void PlayKeyPickup()
    {
        audioManager.PlaySound(5);
    }
}
