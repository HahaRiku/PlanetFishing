using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMgr : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void Show統神走路()
    {
        animator.SetTrigger("統神走路");
    }

    public void Show統神跌倒()
    {
        animator.SetTrigger("統神跌倒");
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
