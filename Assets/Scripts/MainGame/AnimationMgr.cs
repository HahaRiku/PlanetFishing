using UnityEngine;

public class AnimationMgr : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void ShowVideo(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}
