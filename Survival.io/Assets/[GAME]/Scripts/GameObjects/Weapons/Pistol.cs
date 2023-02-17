using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseBulletSpawner
{
    public override void Start()
    {
        speedTime = 0.5f;
        maxBulletCount = 15;
        currentBulletCount = maxBulletCount;
    }

    /*private void OnEnable()
    {
        if (!enabled) return;

        EventManager.OnAmmoIncrease.AddListener(() =>
        maxBulletCount += 5);

        EventManager.OnSpeedIncrease.AddListener(() => 
        speedTime -= 0.05f);
    }

    private void OnDisable()
    {
        EventManager.OnAmmoIncrease.RemoveListener(() =>
        maxBulletCount += 5);

        EventManager.OnSpeedIncrease.RemoveListener(() =>
        speedTime -= 0.05f);
    }*/

    /*public void PistolSpeedIncrease()
    {
        speedTime -= 0.05f;
    }
    public void PistolAmmoIncrease()
    {
        maxBulletCount += 5;
    }*/
}
