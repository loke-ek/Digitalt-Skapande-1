using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
    public CanvasGroup fadeCanvas;
    public float fadeDuration = 2f;
    // public string winSceneName = "WinScene";

    private bool triggered = false;

    // EXPERIMNETAL
    [SerializeField] int nextSceneNumber;

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

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            fadeCanvas.alpha = time / fadeDuration;
            yield return null;
        }

        fadeCanvas.alpha = 1f;

        SceneManager.LoadScene(nextSceneNumber);
    }
}