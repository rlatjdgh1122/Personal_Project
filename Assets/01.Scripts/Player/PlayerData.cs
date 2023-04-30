using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerData : MonoBehaviour //��� ��ġ���� ������ ��ġ�� �ʿ��� ��ũ��Ʈ�� ��� ���
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
