using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponList
{
    public string WeaponName;
    public Weapon Weapon;
}

[CreateAssetMenu(menuName = "SO/List/WeaponList")]
public class WeaponListData : ScriptableObject
{
    public List<WeaponList> WeaponList = new(); 
}
