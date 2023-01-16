using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner SharedInstance;

    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;

    [SerializeField] private int targetCoinCount;

    private Vector3 createPos;
    private Vector3 offset;
    private int judge;
    private bool control = true;


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
        GetCoinFirstTime();
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

    public void GetCoin()   
    {
        createPos = GetCoinPosition();
        GameObject coin = GetPooledObject();

        if(coin != null)
        {
            coin.transform.position = createPos;
            createPos.y += 1;
            coin.SetActive(true);
        }
    }


    public Vector3 GetCoinPosition()
    {
        judge = Random.Range(-24, -7/*31-7=24*/);

            if (judge > -16/*31-15=16*/)
            {
                judge += 31;
            }
        

        int r = Random.Range(-24, 24);

            if (control)
            {
                offset = new Vector3(judge, 1, r); 
                control = false;       
                return offset;
            }
            else //if(!control)
            {
                offset = new Vector3(r, 1, judge);  
                control = true;      
                return offset;
            }
    }

    public void GetCoinFirstTime()   
    {
        for (int i = 0; i < targetCoinCount; i++)
        {
            createPos = GetCoinPosition();
            GameObject coin = GetPooledObject();

            if(coin != null)
            {
                coin.transform.position = createPos;
                coin.SetActive(true);
            }
        }
    }
}
