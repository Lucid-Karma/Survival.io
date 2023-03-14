using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private float damage;
    
    // void Start()
    // {
    //     damage = GunController.instance.damage;
    // }

    void FixedUpdate()
    {
        transform.position += transform.forward * bulletSpeed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider other)
    {   
        IDamageable damageable = other.GetComponent<IDamageable>();
        damage = GunController.instance.damage;

        if(damageable != null)
        {
            damageable.Damage(damage);
            gameObject.SetActive(false);
        }

        if (other.gameObject.tag != "CoinDetector")
        {
            gameObject.SetActive(false);
        }
    }
    // private void OnEnable()
    // {
    //     EventManager.OnDamageIncrease.AddListener(() =>
    //     damage += 0.5f);
    // }
    // private void OnDisable()
    // {
    //     EventManager.OnDamageIncrease.RemoveListener(() =>
    //     damage = damage);
    // }
}
