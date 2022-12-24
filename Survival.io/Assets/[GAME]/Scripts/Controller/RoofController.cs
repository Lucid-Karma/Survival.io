using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofController : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController.instance.OutSide = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController.instance.OutSide = true;
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
