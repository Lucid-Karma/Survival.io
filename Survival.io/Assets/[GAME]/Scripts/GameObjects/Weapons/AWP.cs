using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWP : BaseBulletSpawner
{
    public override void Start()
    {
        speedTime = 0.8f;
        damage = 20;
        maxBulletCount = 10;
        currentBulletCount = maxBulletCount;

        SAmount = 0.02f;    // update
        BAmount = 5;    //update
        DAmount = 20;   // update
    }
}
