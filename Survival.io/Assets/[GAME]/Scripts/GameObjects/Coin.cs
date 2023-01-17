using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour, ICollectable
{
    public float moveSpeed;
    CoinMove coinMoveScript;

    private float time = 4;

    private void Start()
    {
        coinMoveScript = GetComponent<CoinMove>();

        transform.DOLocalRotate(new Vector3(0, 360, 0), time, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    public void Collect()
    {
        coinMoveScript.enabled = true;
        Debug.Log("Take Coin");
    }
}
