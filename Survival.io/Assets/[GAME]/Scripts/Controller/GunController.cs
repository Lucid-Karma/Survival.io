using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunController : MonoBehaviour
{
    public List<GameObject> gunList = new List<GameObject>();
    private GameObject tempGun;

    private void Update()
    {
        if (!PlayerController.instance.OutSide)
        {
            for (int i = 0; i < gunList.Count; i++)
            {
                if (gunList[i].activeInHierarchy)
                {
                    tempGun = gunList[i];
                    tempGun.SetActive(false);
                }
            }
        }
        else
        {
            StartCoroutine(GunActivatedTime());
        }
    }
    IEnumerator GunActivatedTime()
    {
        yield return new WaitForSeconds(.15f);
        tempGun.SetActive(true);
    }
}
