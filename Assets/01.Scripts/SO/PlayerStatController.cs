using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Core;

public class PlayerStatController : MonoBehaviour
{
    [SerializeField]
    private WeaponData weapon;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveSpeed -= 5;
            Debug.Log("wwer");
        }
    }
    /*public void ChangedWeapon(WeaponData newWeaponData)
    {
        currentWeaponData = newWeaponData;
        ChangedStatByWeapon();
    }
    private void ChangedStatByWeapon()
    {
        MoveSpeed -= currentWeaponData.weight; //���Կ� ���� ������ ������
        if (MoveSpeed <= 3) MoveSpeed = 3f; //���԰� �� ���ſ�� 1�� ����
    }*/
}
