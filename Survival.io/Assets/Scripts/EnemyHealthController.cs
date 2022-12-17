using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;

    void Start()
    {
        ResetHealth();
    }

    /*public void Damage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            //Character.KillCharacter();
            currentHealth = 0;
        }
        Debug.Log(currentHealth);
    }*/
    private void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
