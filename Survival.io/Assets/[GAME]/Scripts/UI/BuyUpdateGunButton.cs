using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyUpdateGunButton : MonoBehaviour
{
    [SerializeField] private float buyValue;
    [SerializeField] private TextMeshProUGUI buyTMP;
    [SerializeField] private CanvasGroup buyButton;
    [SerializeField] private GameObject[] buyButtons;

    private GameObject tempObject;

    private int updateCounter = 0, i = 0;


    private void Start()
    {
        // buyButton.interactable = false;
    }
    private void Update()
    {
        if (updateCounter < 3)
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

        tempObject = buyButtons[i];
        i++;

        if (buyButtons[i] != null)
        {
            tempObject.SetActive(false);
            buyButtons[i].SetActive(true);
        }

        buyValue *= 4;
        buyTMP.text = buyValue.ToString();

        GunController.instance.gunIncrease();
    }
}
