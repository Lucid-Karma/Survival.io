using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner SharedInstance;

    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;

    [SerializeField] private float enemyCreateTime;

    private Vector3 createPos;
    private Vector3 offset;
    private int targetEnemyCount;
    private int[] enemyPosX;
    private int[] enemyPosZ;
    private float timer;

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

    void Start()
    {
        // GetEnemyFirstTime();
    }

    private void FixedUpdate() // 0.02 sn de bir frame �al���yor.
    {
        if (timer >= enemyCreateTime)
        {
            timer = 0f;

            GameObject runEnemyClone = GetPooledObject();

            if (runEnemyClone != null)
            {
                runEnemyClone.transform.position = GetEnemyPosition();
                runEnemyClone.SetActive(true);
            }
        }
        else timer += 0.02f;
    }

    public void GetEnemyFirstTime()
    {
        targetEnemyCount = Random.Range(15, 25);
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

    public Vector3 GetEnemyPosition()
    {
        
        int x = Random.Range(-5, 14);
        int z = Random.Range(-14, 10);
        offset = new Vector3(x, 0, z);
        return offset;
    }

    /*public void ManageEnemy()   
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
    }*/
}
