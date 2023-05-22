using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponStatManager : MonoBehaviour
{
    private Dictionary<string, WeaponDataSO> _stats = new();

    public static WeaponStatManager Instance;

    public T GetWeaponData<T>(string weaponName) where T : WeaponDataSO
    {
        if (_stats.ContainsKey(weaponName))
        {
            Debug.LogError("�ش��ϴ� ���⸦ ������ ���� �ʽ��ϴ�.");
            return null;
        }
        return _stats[weaponName] as T;
    }
}
