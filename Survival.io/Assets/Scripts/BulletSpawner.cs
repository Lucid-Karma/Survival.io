using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour, IDamageable
{
    public static BulletSpawner SharedInstance;

    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;


    private Vector3 createPos;
    private Vector3 offset;
    private int targetBulletCount;

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

        timer = 0;
    }

    void FixedUpdate()
    {
        // if(timer >= 0.1f)
        // {
        //     GetBullet();
        //     timer = 0;
        // }

        // timer += 0.02f;

        if(timer >= 1f)
        {
            GetBullet();            //runs every second.

            timer = 0f;
            Debug.Log("bbb");
        }
        timer += 0.02f;
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

            DisposeBullet();
    }

    public Vector3 GetBulletPosition()
    {
        return gameObject.transform.position;
    }

    private void DisposeBullet()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                StartCoroutine(WaitBeforeBulletDispose(i));
            }
        }
    }

    IEnumerator WaitBeforeBulletDispose(int bullet)
    {
        yield return new WaitForSeconds(1f);
        pooledObjects[bullet].SetActive(false);
    }

    private void DisposeOnTrigger()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].SetActive(false);
            }
        }
    }

    public void Damage()
    {
        DisposeOnTrigger();
    }
}
