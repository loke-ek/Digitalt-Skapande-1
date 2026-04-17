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
    [SerializeField] private Volume invisibilityVolume;


    public bool isStressRising;

    // LEVEL TRACKING
    [SerializeField] int LevelNumber;

    // STRESS EFFECT
    private Vignette vignette;
    private float maxIntensity = 0.53f;
    private float maxSmoothness = 0.16f;

    // INVISIBILITY EFFECTS
    private Bloom bloom;
    private ChromaticAberration chromaticAberration;
    private WhiteBalance whiteBalance;

    private Coroutine invisCoroutine;
    bool inVision = false;

    private void Start()
    {
        playerSr = GetComponent<SpriteRenderer>();
        movement = GetComponent<Movement>();

        PlayerPrefs.SetInt("LastPlayedLevel", LevelNumber);

        // invisibility effects off at start
        if (invisibilityVolume != null)
            invisibilityVolume.weight = 0f;

        //red stress
        if (globalVolume.profile.TryGet(out vignette))
        {
            vignette.intensity.overrideState = true;
            vignette.smoothness.overrideState = true;

            vignette.intensity.value = 0f;
            vignette.smoothness.value = 0f;
        }

        //invivible stuff
        if (invisibilityVolume.profile.TryGet(out bloom))
        {
            bloom.intensity.overrideState = true;
            bloom.intensity.value = 0f;
        }

        if (invisibilityVolume.profile.TryGet(out chromaticAberration))
        {
            chromaticAberration.intensity.overrideState = true;
            chromaticAberration.intensity.value = 0f;
        }

        if (invisibilityVolume.profile.TryGet(out whiteBalance))
        {
            whiteBalance.temperature.overrideState = true;
            whiteBalance.temperature.value = 0f;
        }
    }

    private void Update()
    {
        // UI
        stressBar.fillAmount = stress / 100f;
        sugarBar.fillAmount = sugar / 100f;

        if (inVision && !movement.isInvisible)
        {
            stress = Mathf.Min(stress + rechargeRate * Time.deltaTime, 100f);
            isStressRising = true;
        }
        else
        {
            isStressRising = false;
        }

        //invisible
        if (sugar >= 100)
        {
            FindAnyObjectByType<AudioManager>().PlaySound(2);

            if (invisCoroutine != null)
                StopCoroutine(invisCoroutine);

            invisCoroutine = StartCoroutine(InvisibilityCor());

            sugar = 0;
            stress = 0;
        }

        //deathh
        if (stress >= 100)
        {
            SceneManager.LoadScene("DeathScene");
        }

        HandleVignette();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //candy
        if (collision.CompareTag("CandyA"))
        {
            FindAnyObjectByType<AudioManager>().PlaySound(1);
            sugar += 15;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("CandyB"))
        {
            FindAnyObjectByType<AudioManager>().PlaySound(1);
            sugar += 30;
            Destroy(collision.gameObject);
        }

        //vision
        if (collision.CompareTag("Vision"))
        {
            if (movement.isInvisible) return;

            inVision = true;

            FindAnyObjectByType<AudioManager>().PlaySound(4);
        }
    }
    public void CandyB()
    {
        sugar += 30;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Vision"))
        {
            inVision = false;
            isStressRising = false;
        }
    }

    IEnumerator InvisibilityCor()
    {
        movement.SetInvisible(true);

        isStressRising = false;

        // turn on
        invisibilityVolume.weight = 1f;

        if (bloom != null)
            bloom.intensity.value = 5f;

        if (chromaticAberration != null)
            chromaticAberration.intensity.value = 1f;

        if (whiteBalance != null)
            whiteBalance.temperature.value = -50f;

        yield return new WaitForSeconds(3);

        movement.SetInvisible(false);

        //turn off
        invisibilityVolume.weight = 0f;

        if (bloom != null)
            bloom.intensity.value = 0f;

        if (chromaticAberration != null)
            chromaticAberration.intensity.value = 0f;

        if (whiteBalance != null)
            whiteBalance.temperature.value = 0f;
    }

    void HandleVignette()
    {
        if (vignette == null) return;

        if (movement.isInvisible)
        {
            // Force it OFF while invisible
            vignette.intensity.value = 0f;
            vignette.smoothness.value = 0f;
            return;
        }

        if (isStressRising)
        {
            vignette.color.value = Color.red;

            vignette.intensity.value = Mathf.MoveTowards
            (
                vignette.intensity.value,
                maxIntensity,
                Time.deltaTime * 4f
            );

            vignette.smoothness.value = Mathf.MoveTowards
            (
                vignette.smoothness.value,
                maxSmoothness,
                Time.deltaTime * 4f
            );
        }
        else
        {
            vignette.intensity.value = Mathf.MoveTowards(
                vignette.intensity.value,
                0f,
                Time.deltaTime * 4f
            );

            vignette.smoothness.value = Mathf.MoveTowards(
                vignette.smoothness.value,
                0f,
                Time.deltaTime * 4f
            );
        }
    }
}
