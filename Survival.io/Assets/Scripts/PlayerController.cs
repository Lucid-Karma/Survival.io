using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ExecutingState
{
    OUTRUN,
    OUTIDLE,
    INRUN,
    INIDLE
}

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    PlayerStates currentState;

    public OutRunningState outRunningState = new OutRunningState();
    public OutIdleState outIdleState = new OutIdleState();
    public InRunningState inRunningState = new InRunningState();
    public InIdleState inIdleState = new InIdleState();

    public ExecutingState executingState;



    [SerializeField] private Rigidbody rigidBody;
    public FixedJoystick joystick;
    public Animator animator;
    [SerializeField] private float moveSpeed;

    //AnimationController animationController;

    public bool OutSide = true;

    private void Start()
    {
        //animationController = GetComponent<AnimationController>();

        currentState = outIdleState;
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector3(joystick.Horizontal * moveSpeed, rigidBody.velocity.y, joystick.Vertical * moveSpeed);

        currentState.UpdateState(this);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rigidBody.velocity);

            if (OutSide)    executingState = ExecutingState.OUTRUN;
            else    executingState = ExecutingState.INRUN;

        }
        else
        {
            if (OutSide)    executingState = ExecutingState.OUTIDLE;
            else    executingState = ExecutingState.INIDLE;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Inside")
        {
            OutSide = false;
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            CoinSpawner.SharedInstance.ManageCoins();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Inside")
        {
            OutSide = true;
        }
    }

    public void SwitchState(PlayerStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
