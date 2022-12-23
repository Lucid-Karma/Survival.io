using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour, IDamageable
{
    public static EnemyHealthController instance;

    public float maxHealth, currentHealth, recoil;

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
            // EventManager.OnEnemyDying.Invoke();

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
