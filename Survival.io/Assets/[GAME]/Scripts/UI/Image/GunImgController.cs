using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunImgController : MonoBehaviour
{
    public List<GameObject> gunImgList = new List<GameObject>();

    private int activeGun = 0;
    private int ActiveGun {
        get
        {
            if(activeGun >= gunImgList.Count - 1)
                activeGun = gunImgList.Count - 1;
            return activeGun;
        }
        set{ activeGun = value;}
    }

    void OnEnable()
    {
        EventManager.OnGunUpdate.AddListener(ActivateGunImg);
    }
    void OnDisable()
    {
        EventManager.OnGunUpdate.RemoveListener(ActivateGunImg);
    }

    void Start()
    {
        foreach (var img in gunImgList)
        {
            img.SetActive(false);
        }

        gunImgList[0].SetActive(true);
    }

    void ActivateGunImg()
    {
        ActiveGun ++;
        foreach (var img in gunImgList)
        {
            img.SetActive(false);
        }

        gunImgList[ActiveGun].SetActive(true);
    }
}
