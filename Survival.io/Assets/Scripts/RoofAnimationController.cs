using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Update()
    {
        if (PlayerController.instance.OutSide == true)
        {
            roofClosing();
        }
        else
        {
            roofOpening();
        }
    }

    private void roofOpening()
    {
        animator.SetBool("isOpening", true);
    }
    private void roofClosing()
    {
        animator.SetBool("isOpening", false);
    }
} 
