using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseBulletSpawner
{
    public override void Start()
    {
        speedTime = 0.5f;
        maxBulletCount = 5;
        currentBulletCount = maxBulletCount;
    }
}
