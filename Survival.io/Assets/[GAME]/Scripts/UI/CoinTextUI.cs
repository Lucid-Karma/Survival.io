using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextUI : MonoBehaviour
{
    public static CoinTextUI instance;

    [SerializeField] private TextMeshProUGUI coinText;

    public float totalCoin = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        coinText.text = totalCoin.ToString();
    }
}
