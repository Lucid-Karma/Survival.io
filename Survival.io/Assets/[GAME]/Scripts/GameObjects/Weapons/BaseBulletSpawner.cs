using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBulletSpawner : MonoBehaviour
{
    public static BaseBulletSpawner SharedInstance;

    public float speedTime;
    public float damage;

    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject objectToPool;
    public int amountToPool;

    protected Vector3 createPos;

    
    protected float timer;

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

    public abstract void Start();

    public void FixedUpdate()
    {
        if (timer >= speedTime)
        {
            GetBullet();
            timer = 0;
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
    }

    public Vector3 GetBulletPosition()
    {
        return gameObject.transform.position;
    }

    // public void SetEnemyHealth(float health)
    // {
    //     health -= damage;
    // }
}
