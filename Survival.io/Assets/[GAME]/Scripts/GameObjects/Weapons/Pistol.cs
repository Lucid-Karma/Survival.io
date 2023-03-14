using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseBulletSpawner
{
    public override void Start()
    {
        speedTime = 0.5f;
        damage = 1;
        maxBulletCount = 15;
        currentBulletCount = maxBulletCount;

        SAmount = 0.05f;
        BAmount = 5;
        DAmount = 20;   // update
    }
}