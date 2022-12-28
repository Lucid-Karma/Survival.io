using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWP : BaseBulletSpawner
{
    public override void Start()
    {
        speed = 0.07f;
        damage = 10;
    }
}
