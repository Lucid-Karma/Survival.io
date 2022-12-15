using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    public int maxHealth;
    private int currentHealth;

    void Start()
    {
        ResetHealth();
    }

    public void Damage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            //Character.KillCharacter();
            currentHealth = 0;
        }
        Debug.Log(currentHealth);
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
