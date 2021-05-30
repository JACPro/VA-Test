using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo animInfo;

    bool canAnimate = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Explode()
    {
        if (canAnimate && animator.GetBool("Exploded") == false)
        {
            animator.SetBool("Exploded", true);
            canAnimate = false;
            StartCoroutine(WaitAnimFinish());
        }
    }

    public void Unexplode()
    {
        if (canAnimate && animator.GetBool("Exploded") == true)
        {
            animator.SetBool("Exploded", false);
            canAnimate = false;
            StartCoroutine(WaitAnimFinish());
        }
    }

    IEnumerator WaitAnimFinish()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        
        canAnimate = true;
    }
}
