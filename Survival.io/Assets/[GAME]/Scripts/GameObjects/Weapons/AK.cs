using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK : BaseBulletSpawner
{
    public override void Start()
    {
        speedTime = 0.12f;
        damage = 2;
        maxBulletCount = 50;
        currentBulletCount = maxBulletCount;

        SAmount = 0.02f;    // update
        BAmount = 5;    //update
        DAmount = 20;   // update
    }
}
