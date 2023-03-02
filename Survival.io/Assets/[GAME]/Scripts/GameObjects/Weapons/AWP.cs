using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWP : BaseBulletSpawner
{
    public override void Start()
    {
        speedTime = 0.8f;
        maxBulletCount = 10;
        currentBulletCount = maxBulletCount;
    }
}
