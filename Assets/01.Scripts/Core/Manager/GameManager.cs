using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Core.Core;
public class GameManager : MonoBehaviour
{
    public PoolListData PoolListData;
    public PlayerDataSO PlayerInitStatData;
    public static GameManager Instance;
    public WeaponDataSO weaponInitStatData => PlayerInitStatData.defaultWeapon;

    public List<WeaponDataSO> weaponDatas = new();

    [SerializeField]
    private Transform _playerPos;
    public Transform playerPos => _playerPos;

    public UnityEvent OnInitSetting;
    public UnityEvent OnSelectWeapon;
    public UnityEvent OnChangeWeapon;
    public UnityEvent OnCreateWeapon;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this);

        PoolManager.Instance = new PoolManager(transform);
        PoolListData.poolData.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.count));

        InitSetting();
    }
    public void InitSetting()
    {
        PlayerData.InitPlayerStatSetting(PlayerInitStatData);
        weaponDatas.Add(weaponInitStatData);
        OnInitSetting?.Invoke();
    }
    public void SelectWeapon(int index)
    {
        if (isCheck(index - 1))
            OnSelectWeapon?.Invoke();

        Debug.Log("무기가 준비되지 않았습니다.");
    }
    public void ChangeWeapon()
    {
        OnChangeWeapon?.Invoke();
    }
    public void CreateWeapon()
    {
        OnCreateWeapon?.Invoke();
    }
    public bool isCheck(int index)
    {
        if (weaponDatas[index] == null) return false;

        return true;
    }
}
