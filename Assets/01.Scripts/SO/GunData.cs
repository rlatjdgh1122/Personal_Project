using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/Gun")]
public class GunData : WeaponData
{
    [Range(3, 20f)]
    public int ammo;
    public bool autoFire;
    public int bulletCount;
    public int piercingCount; //���� �� ��
    [Range(0, 1f)]
    public float spreadAngle;


}
