using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponManager : MonoBehaviour //���ιٲ� ���ȵ��� ����
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
            Debug.LogError("�ش��ϴ� ���⸦ ������ ���� �ʽ��ϴ�.");
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
            Debug.LogError("�ش��ϴ� ����� �������� �ʽ��ϴٶ���.");
            return null;
        }
        else
            return _weapons[weaponName];
    }
}
