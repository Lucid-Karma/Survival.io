using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public static BossController instance;

    [SerializeField] private Animator bossAnimator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider bossCollider;
    [SerializeField] private float moveSpeed, turnSpeed, attackDamage;

    [HideInInspector] public bool attackDamageBool = false;

    private GameObject playerGameObject;

    private void Awake()
    {
        instance = this;
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
        Quaternion rotationGoal = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, turnSpeed); // Smooth change rotation
    }

    private void FixedUpdate()
    {
        moveEnemy();

        if (attackDamageBool)
        {
            PlayerHealthController.instance.currentHealth -= attackDamage;
        }
    }

    private void moveEnemy(/*Vector3 direction*/)   // Enemy straight move by rotation 
    {
        rb.MovePosition(transform.position + (transform.forward * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerGameObject)
        {
            bossAttack();
        }
        if (other.gameObject.CompareTag("Fence"))
        {
            bossCollider.isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerGameObject)
        {
            bossMovement();
        }

        if (other.gameObject.CompareTag("Fence"))
        {
            bossCollider.isTrigger = false;
        }
    }

    private void OnEnable()
    {
        // EventManager.OnEnemyDying.AddListener(enemyMovement);
    }
    private void OnDisable()
    {
        // EventManager.OnEnemyDying.RemoveListener(enemyMovement);
        attackDamageBool = false;
    }

    private void bossAttack()
    {
        int randomNum = Random.Range(1, 4);
        bossAnimator.SetInteger("isAttacking", randomNum);
        attackDamageBool = true;
    }
    private void bossMovement()
    {
        bossAnimator.SetInteger("isAttacking", 0);
        attackDamageBool = false;
    }
}
