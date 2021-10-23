using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMgr : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    void Start()
    {
        
    }

    public void Show統神()
    {
        animator.SetTrigger("統神");
    }

    public void Show冰冰姐()
    {
        animator.SetTrigger("冰冰姐");
    }

    public void Show瑞克搖()
    {
        animator.SetTrigger("瑞克搖");
    }

    public void Show蹦蹦姊()
    {
        animator.SetTrigger("蹦蹦姊");
    }
}
