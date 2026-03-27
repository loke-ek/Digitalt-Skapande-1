using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneIntro : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] float fadeDuration = 2f;
    [SerializeField] float walkDuration = 2f;

    Movement player;

    void Start()
    {
        player = FindAnyObjectByType<Movement>();

        StartCoroutine(IntroSequence());
    }

    IEnumerator IntroSequence()
    {
        float t = 0;

        yield return new WaitForSeconds(0.2f);

        while (t < fadeDuration)
        {
            t += Time.deltaTime;

            float alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);

            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0);

        yield return new WaitForSeconds(0.3f);

        player.StartIntroWalkDown();
    }
}