using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK : BaseBulletSpawner
{
    public override void Start()
    {
        speedTime = 0.12f;
        maxBulletCount = 50;
        currentBulletCount = maxBulletCount;
    }
}
