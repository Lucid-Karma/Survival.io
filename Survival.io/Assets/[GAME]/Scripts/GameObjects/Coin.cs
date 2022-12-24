using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour, ICollectable
{
    [HideInInspector] public Transform playerTransform;
    public float moveSpeed;
    CoinMove coinMoveScript;

    private float time = 4;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Bir objeyi referans göstermeden direkt baðlamanýn yolu
        coinMoveScript = GetComponent<CoinMove>();

        transform.DOLocalRotate(new Vector3(0, 360, 0), time, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    public void Collect()
    {
        // gameObject.SetActive(false);
        // CoinSpawner.SharedInstance.GetCoin();
        coinMoveScript.enabled = true;
    }
}
