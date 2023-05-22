using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class InterfaceWeaponUI
{
    public Image WeaponBackImage;
    public Image WeaponImage;
}
public class UIManager : MonoBehaviour
{
    /*public List<InterfaceWeaponUI> WeaponImages = new();
    public void InitUISetting()
    {
        WeaponImages[0].WeaponImage.sprite = GameManager.Instance.weaponInitStatData.image;
        WeaponImages[0].WeaponImage.gameObject.SetActive(true);
    }

    public void CreatedUISetting(int index)
    {

    }
    public void SeletedUISetting(int index)
    {
        WeaponImages[index].WeaponBackImage.color = new Color(1, 1, 1, 1);
        for (int i = 0; i < WeaponImages.Count; i++)
        {
            if (index != i)
                WeaponImages[i].WeaponBackImage.color = new Color(1, 1, 1, .3f);
        }
    }
    public void ChangedUISetting(int index)
    {
        SeletedUISetting(index);
    }*/
}
