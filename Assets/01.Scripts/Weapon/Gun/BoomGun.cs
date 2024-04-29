using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class BoomGun : Gun
{
    protected override void SpawnBullet()
    {
        BoomBullet b = PoolManager.Instance.Pop(bullet.name) as BoomBullet;
        b.SetDamage(gunData.damage);
        b.SetPositionAndShoot(firePos.position, transform.right);
    }
}
