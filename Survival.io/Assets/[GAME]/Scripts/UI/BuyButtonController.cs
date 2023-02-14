using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyButtonController : MonoBehaviour
{
    [SerializeField] private float buyValue;
    [SerializeField] private TextMeshProUGUI buyTMP;
    [SerializeField] private CanvasGroup buyButton;


    private void Start()
    {
        // buyButton.interactable = false;
    }
    private void Update()
    {
        buyTMP.text = buyValue.ToString();

        if (CoinTextUI.instance.totalCoin < buyValue)
        {
            buyButton.interactable = false;
        }
        else
        {
            buyButton.interactable = true;
        }
    }

    public void BuyButtonMethod()
    {
        CoinTextUI.instance.totalCoin -= buyValue;

        buyValue += (int)(buyValue * 20 / 100);
        buyTMP.text = buyValue.ToString();
    }
}
