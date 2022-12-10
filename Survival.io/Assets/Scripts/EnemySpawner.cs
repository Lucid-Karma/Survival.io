using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner SharedInstance;

    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;

    private Vector3 createPos;
    private Vector3 offset;
    private int targetEnemyCount;
    private int[] enemyPosX;
    private int[] enemyPosZ;

    void Awake() 
    {
        SharedInstance = this;

        for (int i = 0; i < amountToPool; i++) 
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
        }
    }

    /*private void OnEnable()
    {
        EventManager.enemyMovementAnimation.AddListener(enemyMovement);
        EventManager.enemyAttackAnimation.AddListener(enemyAttack);
       
    }
    private void OnDisable()
    {
        EventManager.enemyMovementAnimation.RemoveListener(enemyMovement);
        EventManager.enemyAttackAnimation.RemoveListener(enemyAttack);
    }*/

    void Start()
    {
        GetEnemyFirstTime();
    }

    public void GetEnemyFirstTime()
    {
        targetEnemyCount = Random.Range(15, 25);
        //createPos = GetEnemyPosition();
        for (int i = 0; i < targetEnemyCount; i++)
        {
            createPos = GetEnemyPosition();
            GameObject enemy = GetPooledObject();

            if(enemy != null)
            {
                enemy.transform.position = createPos;
                enemy.SetActive(true);
            }
        }  
    }

    public GameObject GetPooledObject() 
    {
        for (int i = 0; i < pooledObjects.Count; i++) 
        {
            if (!pooledObjects[i].activeInHierarchy) 
            {
                return pooledObjects[i];
            }
        }
        
        return null;
    }

    private int count;
    public void GetEnemy()   
    {
        //count = 2;
        createPos = GetEnemyPosition();
        //for (int i = 0; i < count; i++)
        //{
            GameObject enemy = GetPooledObject();

            if(enemy != null)
            {
                enemy.transform.position = createPos;
                enemy.SetActive(true);
            }
        //}
    }

    public Vector3 GetEnemyPosition()
    {
        
        int x = Random.Range(-10, 10);
        int z = Random.Range(-10, 10);
        offset = new Vector3(x, 0, z);
        return offset;
    }

    public void ManageEnemy()   
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                DisposeEnemy(i);
            }
        }
    }

    public void DisposeEnemy(int enemyObject)
    {
        pooledObjects[enemyObject].SetActive(false);
    }


    private Animator enemyAnimator;
    /*private void enemyAttack()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                enemyAnimator = pooledObjects[i].GetComponent<Animator>();
                enemyAnimator.SetBool("isAttack",true);
            }
        }
    }
    private void enemyMovement() 
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                enemyAnimator = pooledObjects[i].GetComponent<Animator>();
                enemyAnimator.SetBool("isAttack",false);
            }
        }
    }*/

    public void enemyAttack(Collider enemyCollider)
    {
        enemyAnimator = enemyCollider.GetComponent<Animator>();
        enemyAnimator.SetBool("isAttack",true);
    }
    public void enemyMovement(Collider enemyCollider)
    {
        enemyAnimator = enemyCollider.GetComponent<Animator>();
        enemyAnimator.SetBool("isAttack",false);
    }
}
