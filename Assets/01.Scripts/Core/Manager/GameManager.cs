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
    public WeaponUI weaponUI;
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
        weaponUI.Open_Panel();
        _playerController.currentWeapon = weapons[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _playerController.currentWeapon = weapons[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _playerController.currentWeapon = weapons[1];
        }

        if (Input.GetKeyDown(KeyCode.P)) weaponUI.Open_Panel();
    }
    public void ChangeWeapon(int idx)
    {

    }
    public void CreateWeapon(string weaponName) //ui에서 총을 선택할때 사용
    {
        for (int i = 0; i < 4; i++)
        {
            if (weapons[i] == null)
            {
                weapons[i] = WeaponManager.Instance.GetWeapon(weaponName);
                GameObject weapon = Instantiate(weapons[i].gameObject, WeaponPos);
                weapon.SetActive(false);
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
