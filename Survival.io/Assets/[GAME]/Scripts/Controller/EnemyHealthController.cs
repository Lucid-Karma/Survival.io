using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour, IDamageable
{
    public float maxHealth, recoil;
    private float currentHealth;

    void Start()
    {
        ResetHealth();
    }

    public void Damage()
    {
        transform.position -= transform.forward * recoil;
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
