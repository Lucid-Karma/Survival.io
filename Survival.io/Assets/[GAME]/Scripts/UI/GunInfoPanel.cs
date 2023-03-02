using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    void Update()
    {
        if(PlayerController.instance.OutSide)
        {
            panel.SetActive(true);
        }
        else if(!PlayerController.instance.OutSide)
        {
            panel.SetActive(false);
        }
    }
}
