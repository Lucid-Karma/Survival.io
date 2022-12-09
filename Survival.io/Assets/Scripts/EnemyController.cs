using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    State currentState;

    public MovementState movementState = new MovementState();
    public AttackState attackState = new AttackState();

    public Animator enemyAnimator;

    [SerializeField] private float moveSpeed, turnSpeed;
    [SerializeField] private Rigidbody rb;

    private GameObject playerGameObject;

    private void OnEnable()
    {
        EventManager.OnPlayerInteract.AddListener(StartState);
       
    }
    private void OnDisable()
    {
        EventManager.OnPlayerInteract.RemoveListener(StartState);
    }

    private void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        /*Vector3 cameraDirection = canvasTransform.position - cam.transform.position;
        canvasTransform.rotation = Quaternion.LookRotation(cameraDirection);    // Enemy damage text lookRotation to every frame*/

        Vector3 direction = (playerGameObject.transform.position - transform.position).normalized;
        Quaternion rotationGoal = Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, turnSpeed); // Smooth change rotation
    }

    private void FixedUpdate()
    {
        moveEnemy();
    }

    private void moveEnemy(/*Vector3 direction*/)   // Enemy straight move by rotation 
    {
        // rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
        rb.MovePosition(transform.position + (transform.forward * moveSpeed * Time.deltaTime));
    }

    private void enemyAttack()
    {
        enemyAnimator.SetBool("isAttack",true);
    }
    private void enemyMovement() 
    {
        enemyAnimator.SetBool("isAttack", false);
    }

    public void StartState()
    {
        currentState = movementState;
        currentState.EnterState(this);
    }

    public void SwitchState(State state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
