using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunController : MonoBehaviour
{
    public List<GameObject> gunList = new List<GameObject>();
    private GameObject activeGun;

    void Awake()
    {
        foreach (GameObject gun in gunList)
        {
            gun.SetActive(false);
        }
    }

    private void Start()
    {
        activeGun = gunList[1];
        activeGun.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKey("a"))
        {
            gunList[1].SetActive(false);
            gunList[2].SetActive(false);
            gunList[3].SetActive(false);
            activeGun = gunList[0];
        }
        if (Input.GetKey("s"))
        {
            gunList[0].SetActive(false);
            gunList[2].SetActive(false);
            gunList[3].SetActive(false);
            activeGun = gunList[1];
        }
        if (Input.GetKey("d"))
        {
            gunList[0].SetActive(false);
            gunList[1].SetActive(false);
            gunList[3].SetActive(false);
            activeGun = gunList[2];
        }
        if (Input.GetKey("f"))
        {
            gunList[0].SetActive(false);
            gunList[1].SetActive(false);
            gunList[2].SetActive(false);
            activeGun = gunList[3];
        }



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
