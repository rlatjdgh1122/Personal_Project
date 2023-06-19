using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class InterfaceUI : MonoBehaviour
{
    private List<VisualElement> weapon_Backgrounds = new();
    private List<VisualElement> images = new();

    private Button setting_btn;

    public GameObject settingPanel;
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

        setting_btn = root.Q<Button>("setting_btn");

        setting_btn.RegisterCallback<ClickEvent>(p =>
        {
            TimeController.Instance.StopTimeScale();
            settingPanel.SetActive(true);
        });
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingPanel.SetActive(!settingPanel.activeSelf);
            if (settingPanel.activeSelf == true)
                TimeController.Instance.StopTimeScale();
            else
            {
                TimeController.Instance.ResetTimeScale();
            }
        }
    }
    public void OnClickBack()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickCancel()
    {
        settingPanel.SetActive(false);
        TimeController.Instance.ResetTimeScale();
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
        Debug.Log(inx);
        images[inx].style.backgroundImage = new StyleBackground(image);
    }
}
