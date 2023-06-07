using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public void OpenPanel_WeaponSelect()
    {

    }
    public void CreateWeapon(string weaponName)
    {
        GameManager.Instance.CreateWeapon(weaponName);
    }


}
