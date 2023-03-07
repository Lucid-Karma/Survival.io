using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyButtonController : MonoBehaviour
{
    [SerializeField] private float buyValue;
    [SerializeField] private TextMeshProUGUI buyTMP;
    [SerializeField] private CanvasGroup buyButton;

    private int updateCounter = 0;


    private void Start()
    {
        // buyButton.interactable = false;
    }
    private void Update()
    {
        if (updateCounter < 5)
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
        else
        {
            buyTMP.text = "MAX";

            buyButton.interactable = false;
        }
    }

    public void BuyButtonMethod()
    {
        CoinTextUI.instance.totalCoin -= buyValue;

        updateCounter++;

        buyValue += (int)(buyValue * 20 / 100);
        buyTMP.text = buyValue.ToString();
    }

    public void AmmoButton()
    {
        BuyButtonMethod();

        EventManager.OnAmmoIncrease.Invoke();
    }

    public void SpeedButton()
    {
        BuyButtonMethod();

        EventManager.OnSpeedIncrease.Invoke();
    }

    public void DamageButton()
    {
        BuyButtonMethod();

        EventManager.OnDamageIncrease.Invoke();
    }
}
