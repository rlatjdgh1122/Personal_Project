using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/GunData")]
public class GunDataSO : WeaponDataSO
{
    [Range(3, 20f)]
    public int ammocapacity;
    public bool autoFire;
    public int bulletCount;
    public int piercingCount; //관통 개 수
    [Range(0, 1f)]
    public float spreadAngle;


}
