using System.Collections;
using UnityEngine;

public class EnemyBadger : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveTime = 2f;
    public float idleTime = 2f;

    public Animator frontAnimator;
    public Animator backAnimator;

    void Start()
    {
        StartCoroutine(PatrolLoop());
    }

    IEnumerator PatrolLoop()
    {
        while (true)
        {

            frontAnimator.gameObject.SetActive(true);
            backAnimator.gameObject.SetActive(false);

            frontAnimator.Play("walk");

            float t = 0;
            while (t < moveTime)
            {
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
                t += Time.deltaTime;
                yield return null;
            }


            frontAnimator.Play("badger idle");
            yield return new WaitForSeconds(idleTime);


            frontAnimator.gameObject.SetActive(false);
            backAnimator.gameObject.SetActive(true);

            backAnimator.Play("badger enemy back animation");

            t = 0;
            while (t < moveTime)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
                t += Time.deltaTime;
                yield return null;
            }


            backAnimator.Play("badger back idle");
            yield return new WaitForSeconds(idleTime);
        }
    }
}