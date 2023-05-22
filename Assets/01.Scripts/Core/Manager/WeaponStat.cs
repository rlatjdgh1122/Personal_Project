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
            Debug.LogError("해당하는 무기를 가지고 있지 않습니다.");
            return null;
        }
        return _stats[weaponName] as T;
    }
}
