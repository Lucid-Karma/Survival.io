using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        gameObject.SetActive(false);
        CoinSpawner.SharedInstance.GetCoin();
    }
}
