using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BigCoin : MonoBehaviour, ICollectable
{
    [HideInInspector] public Transform playerTransform;
    public float moveSpeed;
    CoinMove coinMoveScript;

    private float time = 4;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Bir objeyi referans g�stermeden direkt ba�laman�n yolu
        coinMoveScript = GetComponent<CoinMove>();

        transform.DOLocalRotate(new Vector3(0, 360, 0), time, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            CoinSpawner.SharedInstance.GetBigCoin();
        }
    }

    public void Collect()
    {
        coinMoveScript.enabled = true;
    }

    private void OnDisable()
    {
        coinMoveScript.enabled = false;
    }
}
