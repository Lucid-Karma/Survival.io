using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP5 : BaseBulletSpawner
{
    public override void Start()
    {
        speedTime = 0.08f;
        maxBulletCount = 50;
        currentBulletCount = maxBulletCount;
    }
}
