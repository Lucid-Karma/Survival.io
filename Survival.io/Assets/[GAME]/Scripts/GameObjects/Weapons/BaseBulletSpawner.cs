using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBulletSpawner : MonoBehaviour
{
    public static BaseBulletSpawner instance;

    public float speedTime;

    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;

    protected Vector3 createPos;

    
    protected float timer;
    public static int maxBulletCount;
    public static int currentBulletCount;       // ?????
    public static bool isReloading = false;

    void Awake() 
    {
        instance = this;
        
        for (int i = 0; i < amountToPool; i++) 
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
        }
    }

    public abstract void Start();

    public void FixedUpdate()
    {
        if(PlayerController.instance.isInsideRun)
        {
            currentBulletCount = maxBulletCount;
            isReloading = false;
        }

        if (timer >= speedTime)
        {
            if (currentBulletCount > 0)
            {
                isReloading = false;
                currentBulletCount --;
                GetBullet();
                //Debug.Log(currentBulletCount);
            }
            else if(currentBulletCount == 0)
            {
                StartCoroutine(Reload());
            }

            timer = 0;
        }

        timer += 0.02f;
    }

    IEnumerator Reload()
    {
        if(isReloading)
            yield break;
        
        isReloading = true;
        // Debug.Log("Reloading...");

        // Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(1.7f);  // 4.083f for running reload.- 3.3f for idle reload.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        currentBulletCount = maxBulletCount;
        isReloading = false;
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

    public void GetBullet()   
    {
        createPos = GetBulletPosition();
        GameObject bullet = GetPooledObject();

            if(bullet != null)
            {
                bullet.transform.position = createPos;
                bullet.transform.rotation = transform.parent.rotation;
                bullet.SetActive(true);
            }
    }

    public Vector3 GetBulletPosition()
    {
        return gameObject.transform.position;
    }
}
