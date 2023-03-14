using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunController : MonoBehaviour
{
    public static GunController instance;
    public List<GameObject> gunList = new List<GameObject>();
    private GameObject activeGun;
    private int i = 0;

    public BaseBulletSpawner[] gunRef;
    public float damage;

    void Awake()
    {
        instance = this;

        foreach (GameObject gun in gunList)
        {
            gun.SetActive(false);
        }
    }

    private void Start()
    {
        activeGun = gunList[0];
        activeGun.SetActive(true);

        damage = gunRef[0].damage;
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
            activeGun.SetActive(true);
            // StartCoroutine(GunActivatedTime());
        }
    }

    IEnumerator GunActivatedTime()
    {
        yield return new WaitForSeconds(.15f);
        activeGun.SetActive(true);
    }

    public void gunIncrease()
    {
        i++;
        activeGun = gunList[i];

        damage = gunRef[i].damage;
    }

    #region Bullet

    public void UpdateSpeed()
    {
        gunRef[i].SpeedIncrease();
        Debug.Log(gunRef[i].name);
    }

    public void UpdateAmmo()
    {
        gunRef[i].AmmoIncrease();
        Debug.Log(gunRef[i].name);
    }

    public void UpdateDamage()
    {
        damage = gunRef[i].DamageIncrease();
        Debug.Log(gunRef[i].name);
    }

    #endregion
    
}
