using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public int Keys;
    public int KeyCards;

    [SerializeField] public TextMeshProUGUI KeyCardText;
    [SerializeField] public TextMeshProUGUI KeyText;

    [SerializeField] private ParticleSystem Particle;

    private ParticleSystem ParticleThingi;

    private void Start()
    {
        KeyCards = 0;
        Keys = 0;
        //keyText.text = "x" + keys.ToString();
        //KeyCardText.text = "x" + KeyCards.ToString();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KeyCard"))
        {
            FindAnyObjectByType<AudioManager>().PlaySound(5);
            KeyCards++;
            //KeyCardText.text = "x" + KeyCards.ToString();
            //SpawnParticles();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            FindAnyObjectByType<AudioManager>().PlaySound(5);
            Keys++;
            //KeyText.text = "x" + Keys.ToString();
            //SpawnParticles();
            Destroy(collision.gameObject);
        }

    }

    private void SpawnParticles()
    {
        ParticleThingi = Instantiate(Particle, transform.position, Quaternion.identity);
    }


}