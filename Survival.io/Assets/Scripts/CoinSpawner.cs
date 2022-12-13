using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner SharedInstance;

    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;


    private Vector3 createPos;
    private Vector3 offset;
    private int targetCoinCount;
    private int[] coinPosX;
    private int[] coinPosZ;


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
                coin.SetActive(true);
            }
        
    }

    public Vector3 GetCoinPosition()
    {
        
        int x = Random.Range(-25, 25);
        int z = Random.Range(-25, 25);
        offset = new Vector3(x, 1, z);
        return offset;
    }

    public void ManageCoins()   
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                DisposeCoin(i);
            }
        }
    }

    public void DisposeCoin(int coinObject)
    {
        pooledObjects[coinObject].SetActive(false);
    }

    public void DisposeOnTrigger(Collider coinCollider)
    {
        coinCollider.gameObject.SetActive(false);
    }

    public void GetCoinFirstTime()   
    {
        targetCoinCount = Random.Range(4, 10);
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
