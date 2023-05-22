using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "SO/weaponData")]
public class WeaponDataSO : ScriptableObject
{
    public string WeaponName; // 무기 네임
    public Sprite image; //무기 이미지
    public float damage; //데미지
    public float attackDelay; //공격 딜레이
    public float stunDuration; //기절 시간
    public float knockBack; //넉백
    public float weight; //무게
    public int UseStamina; //사용하는 스태미나
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AnimatorOverrideController animController;

    public void Awake()
    {
        
    }
}
