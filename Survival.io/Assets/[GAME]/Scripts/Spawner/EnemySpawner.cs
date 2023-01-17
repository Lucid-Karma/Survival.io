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
                Debug.Log(runEnemyClone.name + " " + runEnemyClone.transform.position);
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
        
            judge = Random.Range(-30, -24/*31-7=24*/);

            if (judge > -27/*31-15=16*/)
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
}
