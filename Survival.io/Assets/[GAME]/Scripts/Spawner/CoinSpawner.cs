using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner SharedInstance;

    public List<GameObject> smallPooledObjects = new List<GameObject>();
    public List<GameObject> bigPooledObjects = new List<GameObject>();
    public GameObject[] objectToPool;
    public int amountToPool, amountToPoolBigCoin;

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
            GameObject obj = (GameObject)Instantiate(objectToPool[0]);
            obj.SetActive(false); 
            smallPooledObjects.Add(obj);
        }

        for (int j = 0; j < amountToPoolBigCoin; j++) 
        {
            GameObject Bobj = (GameObject)Instantiate(objectToPool[1]);  // ?????
            Bobj.SetActive(false); 
            bigPooledObjects.Add(Bobj);
        }
    }

    void Start()
    {
        GetBigCoinFirstTime();
    }

    public GameObject GetSmallPooledObject() 
    {
        for (int i = 0; i < smallPooledObjects.Count; i++) 
        {
            if (!smallPooledObjects[i].activeInHierarchy) 
            {
                return smallPooledObjects[i];
            }
        }
        
        return null;
    }
    public GameObject GetBigPooledObject() 
    {
        for (int i = 0; i < bigPooledObjects.Count; i++) 
        {
            if (!bigPooledObjects[i].activeInHierarchy) 
            {
                return bigPooledObjects[i];
            }
        }
        
        return null;
    }

    public void GetSmallCoin(Vector3 pos)   
    {
        GameObject coin = GetSmallPooledObject();

        if(coin != null)
        {
            coin.transform.position = pos;
            pos.y += 1;
            coin.SetActive(true);
        }
    }
    public void GetBigCoin()   
    {
        createPos = GetCoinPosition();
        GameObject coin = GetBigPooledObject();

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

    public void GetBigCoinFirstTime()   
    {
        for (int i = 0; i < targetCoinCount; i++)
        {
            createPos = GetCoinPosition();
            GameObject coin = GetBigPooledObject();

            if(coin != null)
            {
                coin.transform.position = createPos;
                coin.SetActive(true);
            }
        }
    }

    public GameObject DisabledCoin(GameObject coin)
    {
        for (int i = 0; i < bigPooledObjects.Count; i++)
        {
            if (bigPooledObjects.Contains(coin))
            {
                return bigPooledObjects[i];
            }
        }
        return null;
    }
}
