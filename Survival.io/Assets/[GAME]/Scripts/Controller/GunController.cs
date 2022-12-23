using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunController : MonoBehaviour
{
    public List<GameObject> gunList = new List<GameObject>();
    private GameObject activeGun;

    private void Start()
    {
        activeGun = gunList[0];
    }

    private void Update()
    {
        if (!PlayerController.instance.OutSide)
        {
            activeGun.SetActive(false);
        }
        else
        {
            StartCoroutine(GunActivatedTime());
        }
    }
    IEnumerator GunActivatedTime()
    {
        yield return new WaitForSeconds(.15f);
        activeGun.SetActive(true);
    }
}
