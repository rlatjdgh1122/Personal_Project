using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public UIController ui_Controller;
    public PoolListData PoolListData;
    public WeaponInfoListData WeaponListData;

    public static GameManager Instance;

    public List<Weapon> weapons = new();

    [SerializeField]
    private Transform _playerPos;
    public Transform playerPos => _playerPos;
    public Transform WeaponPos;

    private PlayerController _playerController;

    [HideInInspector]
    public List<WeaponDataList> UI_weaponDatas = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this);

        PoolManager.Instance = new PoolManager(transform);

        WeaponManager.Instance = gameObject.AddComponent<WeaponManager>();
        TimeController.Instance = gameObject.AddComponent<TimeController>();

        PoolListData.poolData.ForEach(p =>
        {
            PoolManager.Instance.CreatePool(p.prefab, p.count);

        });
        WeaponListData.WeaponList.ForEach(p =>
        {
            WeaponManager.Instance.CreateWeapon(p.WeaponName, p.Weapon);
            UI_weaponDatas.Add(p);
        });

        _playerController = _playerPos.GetComponent<PlayerController>();

    }
    private void Start()
    {
        Setting();
    }
    private void Setting()
    {
        ui_Controller.weaponUI.Open_Panel();
    }

    private void Update()
    {
        if (weapons[0] != null && Input.GetKeyDown(KeyCode.Alpha1))
        {
            ui_Controller.interfaceUI.Select_Weapon(0);

            Select(0);
            _playerController.currentWeapon = weapons[0];
        }
        else if (weapons[1] != null && Input.GetKeyDown(KeyCode.Alpha2))
        {
            ui_Controller.interfaceUI.Select_Weapon(1);

            Select(1);
            _playerController.currentWeapon = weapons[1];
        }
        else if (weapons[2] != null && Input.GetKeyDown(KeyCode.Alpha3))
        {
            ui_Controller.interfaceUI.Select_Weapon(2);

            Select(2);
            _playerController.currentWeapon = weapons[2];
        }
        else if (weapons[3] != null && Input.GetKeyDown(KeyCode.Alpha4))
        {
            ui_Controller.interfaceUI.Select_Weapon(3);
            Select(3);

            _playerController.currentWeapon = weapons[3];
        }

        if (Input.GetKeyDown(KeyCode.P)) ui_Controller.weaponUI.Open_Panel();
    }
    public void Start_WeaponSetting()
    {
        ui_Controller.interfaceUI.Select_Weapon(0);

        Select(0);
        _playerController.currentWeapon = weapons[0];
    }
    private void Select(int idx)
    {
        weapons[idx].gameObject.SetActive(true);
        weapons.Select(idx, p => p?.gameObject.SetActive(false));
    }
  
    public void CreateWeapon(string weaponName)
    {
        for (int i = 0; i < 4; i++)
        {
            if (weapons[i] == null)
            {
                weapons[i] = WeaponManager.Instance.GetWeapon(weaponName);
                GameObject weapon = Instantiate(weapons[i].gameObject, WeaponPos);
                //weapon.SetActive(false);
                break;
            }
        }
        return;
    }
    public void WeaponShuffle()
    {
        UI_weaponDatas.Shuffle();
    }
    public void WeaponRemove(int idx)
    {
        UI_weaponDatas.RemoveAt(idx);
    }
}
