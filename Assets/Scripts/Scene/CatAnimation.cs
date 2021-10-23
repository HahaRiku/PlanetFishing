using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator cat01_animator;

    [SerializeField]
    private Animator cat02_animator;

    [SerializeField]
    private Animator cat03_animator;

    [SerializeField]
    private Animator cat04_animator;

    void Start()
    {
        cat01_animator.SetTrigger("Cat_01");
        cat02_animator.SetTrigger("Cat_02");
        cat03_animator.SetTrigger("Cat_01");
        cat04_animator.SetTrigger("Cat_02");
    }
}
