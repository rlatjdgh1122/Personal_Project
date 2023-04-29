using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatController : PlayerData
{
    [SerializeField]
    private PlayerInitStatData initStatData;
    [SerializeField]
    private WeaponData weapon;
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        MoveSpeed = initStatData.moveSpeed;
        Hp = initStatData.hp;
        Stamina = initStatData.stamina;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangedWeapon(weapon);
        }
    }
    public void ChangedWeapon(WeaponData newWeaponData)
    {
        currentWeaponData = newWeaponData;
        ChangedStatByWeapon();
    }
    private void ChangedStatByWeapon()
    {
        MoveSpeed -= currentWeaponData.weight; //무게에 따라 움직임 느려짐
        if (MoveSpeed <= 3) MoveSpeed = 3f; //무게가 더 무거우면 1로 설정
    }
}
