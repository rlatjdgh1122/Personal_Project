using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WeaponDataList
{
    public string WeaponName;
    public Sprite WeaponImage;
    public string Explain;
    public Weapon Weapon;
}

[CreateAssetMenu(menuName = "SO/List/WeaponInfoList")]
public class WeaponInfoListData : ScriptableObject
{
    public List<WeaponDataList> WeaponList = new(); 
}
