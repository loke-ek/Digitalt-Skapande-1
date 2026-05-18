using UnityEngine;

public class CanFix : MonoBehaviour
{
    [SerializeField] Animator can_above_anim;
   public void PlayCanEnding()
    {
        can_above_anim.SetTrigger("PlayEnding");
    }
}
