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

    private bool isStressRising;

    private Vignette vignette;

    private float maxIntensity = 0.53f;
    private float maxSmoothness = 0.16f;

    private float lastStress;



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
            stress = Mathf.Min(stress + rechargeRate * Time.deltaTime, 100f);
            isStressRising = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vision"))
        {
            isStressRising = false;
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

        if (isStressRising)
        {
            vignette.color.value = Color.red;

            vignette.intensity.value = Mathf.MoveTowards(
                vignette.intensity.value,
                maxIntensity,
                Time.deltaTime * 4f
            );

            vignette.smoothness.value = Mathf.MoveTowards(
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
