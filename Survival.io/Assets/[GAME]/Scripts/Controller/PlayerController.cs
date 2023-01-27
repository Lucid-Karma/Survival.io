using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ExecutingState
{
    OUTRUN,
    OUTIDLE,
    INRUN,
    INIDLE,

    IDLERELOAD,
    RUNRELOAD
}

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    PlayerStates currentState;
    CoinMove coinMoveScript;

    public OutRunningState outRunningState = new OutRunningState();
    public OutIdleState outIdleState = new OutIdleState();
    public InRunningState inRunningState = new InRunningState();
    public InIdleState inIdleState = new InIdleState();

    public RuningReloadState runningReloadState = new RuningReloadState();
    public IdlingReloadState idlingReloadState = new IdlingReloadState();

    public ExecutingState executingState;

    [SerializeField] private Rigidbody rigidBody;
    public FixedJoystick joystick;
    public Animator animator;
    [SerializeField] private float moveSpeed, turnSpeed;

    float tempObjectDistance, keepObjectDistance;
    GameObject keepObject;
    Quaternion rotationGoal;

    //AnimationController animationController;

    public bool OutSide = true;
    
    public bool isInsideRun = false;
    public void SetBool(bool insideOrNot)
    {
        isInsideRun = insideOrNot;
    }

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        //animationController = GetComponent<AnimationController>();

        currentState = outIdleState;
        coinMoveScript = GetComponent<CoinMove>();
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector3(joystick.Horizontal * moveSpeed, rigidBody.velocity.y, joystick.Vertical * moveSpeed);

        calculateRotation();

        if (OutSide)
        {
            Vector3 direction = (keepObject.transform.position - transform.position).normalized;
            rotationGoal = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, turnSpeed); // Smooth change rotation
        }

        if (!keepObject.activeInHierarchy)
        {
            keepObject = null;
        }


        /*Vector3 direction = (keepObject.transform.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, turnSpeed); // Smooth change rotation*/

        currentState.UpdateState(this);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            if (!OutSide)
            {
                transform.rotation = Quaternion.LookRotation(rigidBody.velocity);
                // keepObject = null;
            }
            // transform.rotation = Quaternion.LookRotation(rigidBody.velocity);

            if (OutSide)    //executingState = ExecutingState.OUTRUN;
            {
                if(BaseBulletSpawner.isReloading)
                    executingState = ExecutingState.RUNRELOAD;
                else if(!BaseBulletSpawner.isReloading)
                    executingState = ExecutingState.OUTRUN;
            }
            else    executingState = ExecutingState.INRUN;

        }
        else
        {
            if (OutSide)    //executingState = ExecutingState.OUTIDLE;
            {
                if(BaseBulletSpawner.isReloading)
                    executingState = ExecutingState.IDLERELOAD;
                else if(!BaseBulletSpawner.isReloading)
                    executingState = ExecutingState.OUTIDLE;
            }
            else    executingState = ExecutingState.INIDLE;
        }

        keepObject = null;
    }

    public void SwitchState(PlayerStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }

    private void calculateRotation()
    {
        for (int i = 0; i < EnemySpawner.SharedInstance.pooledObjects.Count; i++)
        {
            tempObjectDistance = Vector3.Distance(transform.position, EnemySpawner.SharedInstance.pooledObjects[i].transform.position);

            if (keepObject == null && EnemySpawner.SharedInstance.pooledObjects[i].activeSelf)
            {
                keepObjectDistance = tempObjectDistance;

                keepObject = EnemySpawner.SharedInstance.pooledObjects[i];
            }

            else if (EnemySpawner.SharedInstance.pooledObjects[i].activeSelf)
            {
                if (tempObjectDistance < keepObjectDistance)
                {
                    keepObjectDistance = tempObjectDistance;

                    keepObject = EnemySpawner.SharedInstance.pooledObjects[i];
                }
            }
        }
    }
}
