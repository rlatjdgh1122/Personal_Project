using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponManager : MonoBehaviour //새로바뀐 스탯들을 리턴
{
    private Dictionary<string, WeaponDataSO> _stats = new();
    private Dictionary<string, Weapon> _weapons = new();
    public static WeaponManager Instance;
    public Transform WeaponPivot;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(Instance);
    }
/*    public T GetWeaponData<T>(string weaponName) where T : WeaponDataSO
    {
        if (_stats.ContainsKey(weaponName) == false)
        {
            Debug.LogError("해당하는 무기를 가지고 있지 않습니다.");
            return null;
        }
        return _stats[weaponName] as T;
    }*/
    public void CreateWeapon(string weaponName, Weapon weapon)
    {
        _weapons.Add(weaponName, weapon);
    }
    public Weapon GetWeapon(string weaponName)
    {
        if (_weapons.ContainsKey(weaponName) == false)
        {
            Debug.LogError("해당하는 무기는 존재하지 않습니다람쥐.");
            return null;
        }
        else
            return _weapons[weaponName];
    }
}
