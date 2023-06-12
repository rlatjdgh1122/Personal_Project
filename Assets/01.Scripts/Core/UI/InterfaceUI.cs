using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class InterfaceUI : MonoBehaviour
{
    private List<VisualElement> weapon_Backgrounds = new();
    private List<VisualElement> images = new();
    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        weapon_Backgrounds.Add(root.Q<VisualElement>("first_weapon"));
        images.Add(weapon_Backgrounds[0].Q<VisualElement>("image"));

        weapon_Backgrounds.Add(root.Q<VisualElement>("second_weapon"));
        images.Add(weapon_Backgrounds[1].Q<VisualElement>("image"));

        weapon_Backgrounds.Add(root.Q<VisualElement>("third_weapon"));
        images.Add(weapon_Backgrounds[2].Q<VisualElement>("image"));

        weapon_Backgrounds.Add(root.Q<VisualElement>("fourth_weapon"));
        images.Add(weapon_Backgrounds[3].Q<VisualElement>("image"));
    }

    public void Select_Weapon(int idx)
    {
        DeSelect();
        images.Select(idx, i => i.AddToClassList("weapon_image"));
        weapon_Backgrounds[idx].AddToClassList("weapon_select");

    }
    private void DeSelect()
    {
        images.ForEach(p => p.RemoveFromClassList("weapon_image"));
        weapon_Backgrounds.ForEach(p => p.RemoveFromClassList("weapon_select"));
    }
    public void Insert_weaponImage(int inx, Sprite image)
    {
        images[inx].style.backgroundImage = new StyleBackground(image);
    }
}
