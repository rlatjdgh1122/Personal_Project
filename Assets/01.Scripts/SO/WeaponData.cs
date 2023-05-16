using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/weaponData")]
public class WeaponData : ScriptableObject
{
    public float damage; //데미지
    public float attackDelay; //공격 딜레이
    public float stunDuration; //기절 시간
    public float knockBack; //넉백
    public float weight; //무게
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AnimatorOverrideController animController;
}
