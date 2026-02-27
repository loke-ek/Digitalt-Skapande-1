using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerStatsScript : MonoBehaviour
{
    SpriteRenderer playerSr;

    [SerializeField] StartMenu sceneManager_s;

    [SerializeField] public float stress;
    [SerializeField] public Image stressBar;

    [SerializeField] public float sugar;
    [SerializeField] public Image sugarBar;

    [SerializeField] public float rechargeRate = 10.0f;

    Movement movement;

    [SerializeField] private Volume globalVolume;

    private Vignette vignette;

    private float maxIntensity = 0.53f;
    private float maxSmoothness = 0.16f;

    private float lastStress;
    private float vignetteFadeSpeed = 2f;


    private void Start()
    {
        playerSr = GetComponent<SpriteRenderer>();
        movement = GetComponent<Movement>();

        if (globalVolume.profile.TryGet(out vignette))
        {
            vignette.intensity.overrideState = true;
            vignette.smoothness.overrideState = true;

            vignette.intensity.value = 0f;
            vignette.smoothness.value = 0f;
        }
    }

    private void Update()
    {
        stressBar.fillAmount = stress / 100; // uppdaterar stressbar
        sugarBar.fillAmount = sugar / 100; // uppdaterar sugarbar

        if (vignette != null)
        {
            vignette.intensity.value = 0.53f;
        }

        if (sugar >= 100)
        {
            // FindAnyObjectByType<AudioManager>().PlaySound(2);
            StartCoroutine(InvisibilityCor());
            sugar = 0;
            stress = 0;
        }
        
        if(stress >= 100)
        {
            SceneManager.LoadScene("DeathScene");
        }

        HandleVignette();
        lastStress = stress;
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
        movement.SetInvisible(true);
        yield return new WaitForSeconds(3);
        movement.SetInvisible(false);

    }


    public void CandyB()
    {
        sugar += 30;
    }

    void HandleVignette()
    {
        if (vignette == null) return;

        // Check if stress is increasing
        bool stressRising = stress > lastStress;

        if (stressRising)
        {
            // Normalize stress (0–100  0–1)
            float normalizedStress = stress / 100f;

            vignette.intensity.value = Mathf.Lerp(0f, maxIntensity, normalizedStress);
            vignette.smoothness.value = Mathf.Lerp(0f, maxSmoothness, normalizedStress);
        }
        else
        {
            // Fade out smoothly
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0f, Time.deltaTime * vignetteFadeSpeed);
            vignette.smoothness.value = Mathf.Lerp(vignette.smoothness.value, 0f, Time.deltaTime * vignetteFadeSpeed);
        }
    }

}
