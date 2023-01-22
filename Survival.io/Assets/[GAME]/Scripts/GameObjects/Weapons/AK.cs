using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK : BaseBulletSpawner
{
    public override void Start()
    {
        speedTime = 0.07f;
        maxBulletCount = 100;
        currentBulletCount = maxBulletCount;
    }
}
