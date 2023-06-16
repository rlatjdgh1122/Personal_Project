using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "SO/weaponData")]
public class WeaponDataSO : ScriptableObject
{
    [Range(15f, 70f)]
    public int damage; //데미지
    [Range(.1f, 1f)]
    public float attackDelay; //공격 딜레이
    [Range(.5f, 3f)]
    public float stunDuration; //기절 시간
    [Range(10f, 50f)]
    public float knockBack; //넉백
    [Range(.5f, 3f)]
    public float weight; //무게
    [Range(7f, 30f)]
    public int UseStamina; //사용하는 스태미나
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AnimatorOverrideController animController;
}
