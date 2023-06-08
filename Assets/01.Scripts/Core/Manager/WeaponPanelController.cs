using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponPanelController : MonoBehaviour
{
    private VisualElement _background;

    private Button _select_first;
    private Button _select_second;
    private Button _select_third;

    private Button _refresh;

    public static WeaponPanelController Instance;

    private void Awake()
    {
        if (Instance == null) { Instance = this; } else Destroy(this);
    }
    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _background = root.Q<VisualElement>("background");

        _select_first = root.Q<Button>("select_first");
        _select_second = root.Q<Button>("select_second");
        _select_third = root.Q<Button>("select_third");

        _refresh = root.Q<Button>("refresh");
    }
    public void Open_Panel()
    {
        _background.style.display = DisplayStyle.Flex;
    }
    private void Off_Panel()
    {
        _background.style.display = DisplayStyle.None;
    }
    public void CreateWeapon(string weaponName)
    {
        GameManager.Instance.CreateWeapon(weaponName);
    }


}
