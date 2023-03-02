using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAWP : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    public float damage;
    
    void FixedUpdate()
    {
        transform.position += transform.forward * bulletSpeed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.Damage(damage);
            // gameObject.SetActive(false);
        }

        if (other.gameObject.tag != "CoinDetector" && other.gameObject.tag != "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
