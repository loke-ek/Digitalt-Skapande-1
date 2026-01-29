using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class FakeChest : MonoBehaviour
{
    public Sprite Closed;
    public Sprite Open;

    private SpriteRenderer sr;

    public GameObject uiText;
    public GameObject WorkText;

    public int mashRequired = 10;

    private bool playerInRange;
    private bool trappingPlayer;
    private bool hasTrappedPlayer; //one-time per chest

    private int mashCount;
    private Movement playerMovement;
    private PlayerStatsScript Stress;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Closed;

        uiText.SetActive(false);
        WorkText.SetActive(false);
    }

    void Update()
    {
        // Normal interaction (only if this chest hasn't trapped yet)
        if (playerInRange && !hasTrappedPlayer && !trappingPlayer &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            OpenAndTrap();
            //stress = Mathf.Min(stress + rechargeRate * Time.deltaTime, 100f);
        }

        // Mash to escape phase
        if (trappingPlayer)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                mashCount++;

                // Trigger camera shake
                var cameraShake = FindAnyObjectByType<CameraShake>();
                if (cameraShake != null)
                    cameraShake.Shake(0.1f, 0.08f);

                if (mashCount >= mashRequired)
                {
                    ReleasePlayer();
                }
            }
            return;
        }


        // Show prompt only if usable
        uiText.SetActive(playerInRange && !hasTrappedPlayer);
    }

    void OpenAndTrap()
    {
        sr.sprite = Open;
        uiText.SetActive(false);
        WorkText.SetActive(true);

        trappingPlayer = true;
        mashCount = 0;

        if (playerMovement != null)
            playerMovement.Freeze();
    }

    void ReleasePlayer()
    {
        trappingPlayer = false;
        hasTrappedPlayer = true; //permanently spent chest

        WorkText.SetActive(false);

        if (playerMovement != null)
            playerMovement.Unfreeze();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            playerMovement = collision.GetComponent<Movement>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}

