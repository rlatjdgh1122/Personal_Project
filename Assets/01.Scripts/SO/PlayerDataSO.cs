using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerStatData")]
public class PlayerDataSO : ScriptableObject
{
    public float moveSpeed;
    public float hp;
    public float stamina;
    public WeaponDataSO defaultWeapon;
}
