using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    [HideInInspector] public Transform playerTransform;

    [SerializeField] private float coinValue;

    Coin coinScript;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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
            CoinTextUI.instance.totalCoin += coinValue;

            this.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
