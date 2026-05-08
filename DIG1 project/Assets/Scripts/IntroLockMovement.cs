using System.Collections;
using UnityEngine;

public class IntroLockMovement : MonoBehaviour
{
    [SerializeField] Movement playerMovement;

    [SerializeField] float introDuration = 17f;

    IEnumerator Start()
    {
        Debug.Log("FREEZE");

        playerMovement.FreezeIntro();

        yield return new WaitForSeconds(introDuration);

        Debug.Log("UNFREEZE");

        playerMovement.Unfreeze();
    }
}