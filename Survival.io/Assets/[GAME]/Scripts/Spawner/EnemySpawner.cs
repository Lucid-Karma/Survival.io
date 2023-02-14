using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner SharedInstance;

    public List<GameObject> pooledObjects = new List<GameObject>();

    [SerializeField] private GameObject[] enemyPrefab;

    [SerializeField] private float maxEnemyCount, enemyCreateCount;
    private int judge;
    private float timer;
    private Vector3 offset;
    [Tooltip("EnemyListte hangi siradan oluşuma devam edeceğini gösterir.")]

    private int listEnemyTurnIndex;
    public int ListEnemyTurnIndex 
    { get { return listEnemyTurnIndex; }

        set 
        {
            if (value > 2) 
                listEnemyTurnIndex = 2;
            else 
                listEnemyTurnIndex = value;
        }
    }

    public bool enemyCreateFinish;

    [Header("Enemy Spawn Manager")]
    // [SerializeField] private GameObject levelBOSS;
    [SerializeField] private float[] enemyCreateTime;
    [Tooltip("Listedeki hangi Enemyden başlayacağimizi seçiyoruz.")]
    public int[] listEnemyTurn;
    private int intinationalI;

    // [SerializeField] private GameObject levelBOSS;


    // GameObject runEnemyClone;

    void Awake()
    {
        SharedInstance = this;

        for (int j = 0; j < enemyPrefab.Length-1; j++)
        {
            for (int i = 0; i < maxEnemyCount; i++)
            {
                GameObject obj = Instantiate(enemyPrefab[j]);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
        GameObject bossObject = Instantiate(enemyPrefab[enemyPrefab.Length - 1]);
        bossObject.SetActive(false);
        pooledObjects.Add(bossObject);
    }

    private void Start()
    {
        // enemyCreateTime = (enemyCreateTime * 60) / 100;
        intinationalI = 0;
        ListEnemyTurnIndex = 0;
    }
    private void FixedUpdate()
    {
        if (!PlayerController.instance.OutSide)
        {
            return;
        }

        if (timer >= enemyCreateTime[ListEnemyTurnIndex] && !enemyCreateFinish)
        {

            if (enemyCreateCount >= maxEnemyCount)
            {
                Debug.Log("num " + listEnemyTurnIndex + " created!!");

                ListEnemyTurnIndex ++;

                enemyCreateCount = 0;
                intinationalI = listEnemyTurn[ListEnemyTurnIndex];
            }
            else
            {
                timer = 0f;
                // index = Random.Range(0, spawnPoints.Length);

                GameObject runEnemyClone = GetPooledObject();

                if (runEnemyClone != null)
                {
                    runEnemyClone.transform.position = GetEnemyPosition(); //spawnPoints[index].transform.position;
                    runEnemyClone.SetActive(true);
                }

                Debug.Log("enemy created");
                enemyCreateCount += 1;

                if (pooledObjects[pooledObjects.Count-1].activeInHierarchy)
                {
                    Debug.Log("enabled");
                    this.enabled = false;
                }
            }
        }
        else timer += 0.01f;

    }

    public GameObject GetPooledObject()
    {
        for (int i = intinationalI; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }

    private bool control = true;

    public Vector3 GetEnemyPosition()
    {
        // Exclude range 27, -27. Within 30, -30.

        judge = Random.Range(-30, -24);

        if (judge > -27)
        {
            judge += 54;
        }

        int r = Random.Range(-30, 30);

        if (control)
        {
            offset = new Vector3(judge, 0, r);
            control = false;
            return offset;
        }
        else //if(!control)
        {
            offset = new Vector3(r, 0, judge);
            control = true;
            return offset;
        }
    }

    /*public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;

    [SerializeField] private float enemyCreateTime;

    private Vector3 offset;
    private float timer;
    private int judge;

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

    private void FixedUpdate() // 0.02 sn de bir frame calisiyor.
    {
        if (timer >= enemyCreateTime)
        {
            timer = 0f;

            GameObject runEnemyClone = GetPooledObject();

            if (runEnemyClone != null)
            {
                runEnemyClone.transform.position = GetEnemyPosition();
                runEnemyClone.SetActive(true);
                // Debug.Log(runEnemyClone.name + " " + runEnemyClone.transform.position);
            }
        }
        else timer += 0.02f;
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

    private bool control = true;
    public Vector3 GetEnemyPosition()
    {
           // Exclude range 27, -27. Within 30, -30.
        
            judge = Random.Range(-30, -24);

            if (judge > -27)
            {
                judge += 54;
            }
        

        int r = Random.Range(-30, 30);

            if (control)
            {
                offset = new Vector3(judge, 0, r); 
                control = false;       
                return offset;
            }
            else //if(!control)
            {
                offset = new Vector3(r, 0, judge);  
                control = true;      
                return offset;
            }
    }
            */
}
