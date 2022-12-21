using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private bool activatedControl = true;

    void FixedUpdate()
    {
        transform.position += transform.forward * bulletSpeed * Time.fixedDeltaTime;

        if (activatedControl)
        {
            activatedControl = false;
            StartCoroutine(DisposeBullet());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.Damage();
            gameObject.SetActive(false);
        }
    }
    IEnumerator DisposeBullet()
    {
        yield return new WaitForSeconds(1f);

        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }

        activatedControl = true;
    }
}
