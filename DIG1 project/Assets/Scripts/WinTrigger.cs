using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
    public CanvasGroup fadeCanvas;
    public float fadeDuration = 2f;
    public string winSceneName = "LevelsOptions";

    private bool triggered = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;

            Movement player = other.GetComponent<Movement>();

            if (player != null)
            {
                player.StartWinWalk();
            }

            StartCoroutine(FadeAndLoad());
        }
    }

    IEnumerator FadeAndLoad()
    {
        float time = 0f;

        if (LevelTimer.instance != null)
        {
            LevelTimer.instance.StopTimer();
        }

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            fadeCanvas.alpha = time / fadeDuration;
            yield return null;
        }

        fadeCanvas.alpha = 1f;

        float finalTime = 0f;

        if (LevelTimer.instance != null)
        {
            finalTime = LevelTimer.instance.GetTime();
        }
        else
        {
            Debug.LogError("Timer missing!");
            yield break;
        }

        LevelSettings settings = FindAnyObjectByType<LevelSettings>();

        if (settings != null && LevelDataManager.instance != null)
        {
            int stars = settings.CalculateStars(finalTime);
            LevelDataManager.instance.SaveStars(settings.levelName, stars);
        }

        SceneManager.LoadScene("LevelsOptions");
    }
}