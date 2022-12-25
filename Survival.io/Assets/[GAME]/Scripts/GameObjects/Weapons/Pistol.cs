using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseBulletSpawner
{
    public override void Start()
    {
        speed = 0.5f;
        damage = 1;
    }
}
