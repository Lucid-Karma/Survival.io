using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    [HideInInspector] public Transform playerTransform;
    Coin coinScript;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Bir objeyi referans g�stermeden direkt ba�laman�n yolu
        coinScript = GetComponent<Coin>();
    }
    void Update()
    {
        Vector3 playerNewTransform = playerTransform.position;
        playerNewTransform.y += 1f;

        transform.position = Vector3.MoveTowards(transform.position, playerNewTransform, coinScript.moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
