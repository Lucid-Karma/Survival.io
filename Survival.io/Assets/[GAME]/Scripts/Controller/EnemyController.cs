using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed, turnSpeed, attackDamage;

    private bool attackDamageBool = false;

    private GameObject playerGameObject;

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
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (other.gameObject == playerGameObject)
        {
            enemyAttack();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerGameObject)
        {
            enemyMovement();
        }
    }

    private void enemyAttack()
    {
        enemyAnimator.SetBool("isAttack", true);
        attackDamageBool = true;
    }
    private void enemyMovement()
    {
        enemyAnimator.SetBool("isAttack", false);
        attackDamageBool = false;
    }
}
