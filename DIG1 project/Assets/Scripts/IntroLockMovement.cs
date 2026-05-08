using System.Collections;
using UnityEngine;

public class IntroLockMovement : MonoBehaviour
{
    [SerializeField] Movement playerMovement;

    [SerializeField] float introDuration = 17f;

    IEnumerator Start()
    {
        playerMovement.Freeze();

        yield return new WaitForSeconds(introDuration);

        playerMovement.Unfreeze();
    }
}