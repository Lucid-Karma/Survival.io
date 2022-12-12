using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    public void OutRunningAnimation()
    {
        animator.SetBool("isOutRunning", true);
        animator.SetBool("isOutIdle", false);
        animator.SetBool("isInRunning", false);
        animator.SetBool("isInIdle", false);
    }
    public void OutIdleAnimation()
    {
        animator.SetBool("isOutIdle", true);
        animator.SetBool("isOutRunning", false);
        animator.SetBool("isInRunning", false);
        animator.SetBool("isInIdle", false);
    }
    public void InRunningAnimation()
    {
        animator.SetBool("isOutIdle", false);
        animator.SetBool("isOutRunning", false);
        animator.SetBool("isInRunning", true);
        animator.SetBool("isInIdle", false);
    }
    public void InIdleAnimation()
    {
        animator.SetBool("isOutIdle", false);
        animator.SetBool("isOutRunning", false);
        animator.SetBool("isInRunning", false);
        animator.SetBool("isInIdle", true);
    }
}
