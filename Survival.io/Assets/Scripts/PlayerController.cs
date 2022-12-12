using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private FixedJoystick joystick;
    // [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed;

    AnimationController animationController;

    private bool OutSide = true;

    private void Start()
    {
        animationController = GetComponent<AnimationController>();
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector3(joystick.Horizontal * moveSpeed, rigidBody.velocity.y, joystick.Vertical * moveSpeed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rigidBody.velocity);

            if (OutSide) animationController.OutRunningAnimation();
            else animationController.InRunningAnimation();
        }
        else
        {
            if (OutSide) animationController.OutIdleAnimation();
            else animationController.InIdleAnimation();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Inside")
        {
            OutSide = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Inside")
        {
            OutSide = true;
        }
    }
}
