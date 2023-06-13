using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponUI : MonoBehaviour
{

    private UIController ui_Controller;
    private VisualElement _background;

    private Button _select_first;
    private VisualElement _first_image;
    private Label _first_name;
    private Label _first_explain;

    private Button _select_second;
    private VisualElement _second_image;
    private Label _second_name;
    private Label _second_explain;

    private Button _select_third;
    private VisualElement _third_image;
    private Label _third_name;
    private Label _third_explain;

    private Button _refresh;

    public static WeaponUI Instance;


    private int idx0 = 0;
    private int idx1 = 1;
    private int idx2 = 2;

    private int idx = 0;
    private void Awake()
    {
        if (Instance == null) { Instance = this; } else Destroy(this);

        ui_Controller = GetComponentInParent<UIController>();
    }
    private void Start()
    {

        var root = GetComponent<UIDocument>().rootVisualElement;

        _background = root.Q<VisualElement>("background");

        _select_first = root.Q<Button>("select-first");
        _select_second = root.Q<Button>("select-second");
        _select_third = root.Q<Button>("select-third");

        _first_image = root.Q<VisualElement>("first-image");
        _second_image = root.Q<VisualElement>("second-image");
        _third_image = root.Q<VisualElement>("third-image");

        _first_name = root.Q<Label>("first-weaponName");
        _second_name = root.Q<Label>("second-weaponName");
        _third_name = root.Q<Label>("third-weaponName");

        _first_explain = root.Q<Label>("first-explain");
        _second_explain = root.Q<Label>("second-explain");
        _third_explain = root.Q<Label>("third-explain");

        _refresh = root.Q<Button>("refresh");

        _select_first.RegisterCallback<ClickEvent>(OnClick_Selet_first);
        _select_second.RegisterCallback<ClickEvent>(OnClick_Selet_second);
        _select_third.RegisterCallback<ClickEvent>(OnClick_Selet_third);

        _refresh.RegisterCallback<ClickEvent>(OnClick_refresh);
        Off_Panel();
        Open_Panel();
    }

    private void OnClick_refresh(ClickEvent evt)
    {
        UI_Appry(true);
        _refresh.AddToClassList("refresh-disabled");
    }

    private void OnClick_Selet_third(ClickEvent evt)
    {
        Off_Panel();
        CreateWeapon(_third_name.text);
        GameManager.Instance.WeaponRemove(idx2);
        ui_Controller.interfaceUI.Insert_weaponImage(idx++, _first_image.style.backgroundImage.value.sprite);

        Check();
    }

    private void OnClick_Selet_second(ClickEvent evt)
    {
        Off_Panel();
        CreateWeapon(_second_name.text);
        GameManager.Instance.WeaponRemove(idx1);
        ui_Controller.interfaceUI.Insert_weaponImage(idx++, _second_image.style.backgroundImage.value.sprite);

        Check();
    }

    private void OnClick_Selet_first(ClickEvent evt)
    {
        Off_Panel();
        CreateWeapon(_first_name.text);
        GameManager.Instance.WeaponRemove(idx0); ui_Controller.interfaceUI.Insert_weaponImage(idx++, _third_image.style.backgroundImage.value.sprite);

        Check();
    }

    private void Off_Panel()
    {
        _background.style.display = DisplayStyle.None;

    }

    private void UI_Appry(bool value = false) //UI에 이름 이미지 설명 적용
    {
        idx0 = 0;
        idx1 = 1;
        idx2 = 2;
        if (value)
        {
            idx0 = 3;
            idx1 = 4;
            idx2 = 5;
        }
        WeaponDataList first = GameManager.Instance.UI_weaponDatas[idx0];
        WeaponDataList second = GameManager.Instance.UI_weaponDatas[idx1];
        WeaponDataList third = GameManager.Instance.UI_weaponDatas[idx2];

        _first_name.text = first.WeaponName;
        _first_image.style.backgroundImage = new StyleBackground(first.WeaponImage);
        _first_explain.text = first.Explain;

        _second_name.text = second.WeaponName;
        _second_image.style.backgroundImage = new StyleBackground(second.WeaponImage);
        _second_explain.text = second.Explain;

        _third_name.text = third.WeaponName;
        _third_image.style.backgroundImage = new StyleBackground(third.WeaponImage);
        _third_explain.text = third.Explain;
    }
    public void Check()
    {
        if (idx == 1) GameManager.Instance.Start_WeaponSetting();
        TimeController.Instance.ResetTimeScale();
    }
    public void Open_Panel()
    {
        TimeController.Instance.StopTimeScale();

        _background.style.display = DisplayStyle.Flex;
        _refresh.RemoveFromClassList("refresh-disabled");
        GameManager.Instance.WeaponShuffle();
        UI_Appry();
    }

    private void CreateWeapon(string weaponName)
    {
        GameManager.Instance.CreateWeapon(weaponName);
    }
}
