using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerData : MonoBehaviour //모든 수치들을 조정함 수치가 필요한 스크립트에 모두 상속
{
    protected static GameObject currentWeapon;
    protected static WeaponData currentWeaponData;

    protected static float MoveSpeed;
  
    protected static float Hp;

    protected static float Stamina;

    protected Animator anim;
    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
}
