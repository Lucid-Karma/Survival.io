using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    /*private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    void OnEnable()
    {
        EventManager.OnCharacterOutRunning.AddListener(OutRunningAnimation);
        EventManager.OnCharacterOutIdle.AddListener(OutIdleAnimation);
        EventManager.OnCharacterInRunning.AddListener(InRunningAnimation);
        EventManager.OnCharacterInIdle.AddListener(InIdleAnimation);
    }
    void OnDisable()
    {
        EventManager.OnCharacterOutRunning.RemoveListener(OutRunningAnimation);
        EventManager.OnCharacterOutIdle.RemoveListener(OutIdleAnimation);
        EventManager.OnCharacterInRunning.RemoveListener(InRunningAnimation);
        EventManager.OnCharacterInIdle.RemoveListener(InIdleAnimation);
    }
    
    public void OutRunningAnimation()
    {
        Animator.SetBool("isOutRunning", true);
        Animator.SetBool("isOutIdle", false);
        Animator.SetBool("isInRunning", false);
        Animator.SetBool("isInIdle", false);
    }
    public void OutIdleAnimation()
    {
        Animator.SetBool("isOutIdle", true);
        Animator.SetBool("isOutRunning", false);
        Animator.SetBool("isInRunning", false);
        Animator.SetBool("isInIdle", false);
    }
    public void InRunningAnimation()
    {
        Animator.SetBool("isOutIdle", false);
        Animator.SetBool("isOutRunning", false);
        Animator.SetBool("isInRunning", true);
        Animator.SetBool("isInIdle", false);
    }
    public void InIdleAnimation()
    {
        Animator.SetBool("isOutIdle", false);
        Animator.SetBool("isOutRunning", false);
        Animator.SetBool("isInRunning", false);
        Animator.SetBool("isInIdle", true);
    }*/
}
