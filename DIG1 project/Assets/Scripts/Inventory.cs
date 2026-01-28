using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public int keys;
    public int KeyCard;

    [SerializeField] public TextMeshProUGUI KeyCardText;
    [SerializeField] public TextMeshProUGUI keyText;

    [SerializeField] private ParticleSystem Particle;

    private ParticleSystem ParticleThingi;

    private void Start()
    {
        KeyCard = 0;
        keys = 0;
        keyText.text = "x" + keys.ToString();
        KeyCardText.text = "x" + KeyCard.ToString();

        PlayerPrefs.SetInt("TotalGems", 0);
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KeyCard"))
        {
            //FindAnyObjectByType<AudioManeger>().PlaySound(3);
            keys++;
            keyText.text = "x" + keys.ToString();
            SpawnParticles();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            //FindAnyObjectByType<AudioManeger>().PlaySound(3);
            keys++;
            keyText.text = "x" + keys.ToString();
            SpawnParticles();
            Destroy(collision.gameObject);
        }

    }

    private void SpawnParticles()
    {
        ParticleThingi = Instantiate(Particle, transform.position, Quaternion.identity);
    }


}