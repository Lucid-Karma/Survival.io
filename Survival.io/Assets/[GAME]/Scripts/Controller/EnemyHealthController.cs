using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour, IDamageable
{
    public static EnemyHealthController instance;

    public float maxHealth, currentHealth, recoil;
    [SerializeField] private GameObject coinObject;

    private void Awake()
    {
        instance = this;
    }

    public void Damage()
    {
        transform.position -= transform.forward * recoil;
        currentHealth -= 1;

        if (currentHealth <= 0)
        {
            Instantiate(coinObject, new Vector3(transform.position.x,coinObject.transform.position.y,transform.position.z), transform.rotation);

            //CoinSpawner.SharedInstance.GetCoin(transform.position);

            Debug.Log("Enemy Dead !");

            gameObject.SetActive(false);

            ResetHealth();
        }
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
