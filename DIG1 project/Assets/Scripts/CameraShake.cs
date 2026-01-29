using UnityEngine;
using System.Collections;
public class CameraShake : MonoBehaviour
{
    Vector3 originalPos; //original positoin

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeRoutine(duration, magnitude)); //public to accses it from playermovement
    }

    IEnumerator ShakeRoutine(float duration, float magnitude)
    {
        originalPos = transform.localPosition;

        float timer = 0f;

        while (timer < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude; //random shake
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPos + new Vector3(x, y, 0);

            timer += Time.deltaTime;
            yield return null;
        }

        // Reset camera position
        transform.localPosition = originalPos;
    }
}
