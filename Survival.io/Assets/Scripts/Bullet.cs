using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Rigidbody rb;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //BulletSpawner.SharedInstance.GetBullet();
        //rb.AddForce(transform.forward * bulletSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
        //rb.velocity = transform.forward * bulletSpeed;
        transform.position += transform.forward * bulletSpeed * Time.fixedDeltaTime;

        //transform.Rotate(0, PlayerController.instance.transform.rotation.y, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.Damage();
        }
    }
}
