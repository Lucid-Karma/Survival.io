using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BigCoin : MonoBehaviour, ICollectable
{
    [HideInInspector] public Transform playerTransform;
    public float moveSpeed;
    BigCoinMove bigCoinMoveScript;

    private float time = 4;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Bir objeyi referans g�stermeden direkt ba�laman�n yolu

        bigCoinMoveScript = GetComponent<BigCoinMove>();

        transform.DOLocalRotate(new Vector3(0, 360, 0), time, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CoinSpawner.SharedInstance.GetBigCoin();
            gameObject.SetActive(false);
        }
    }

    public void Collect()
    {
        bigCoinMoveScript.enabled = true;
    }

    private void OnDisable()
    {
        bigCoinMoveScript.enabled = false;
    }
}
