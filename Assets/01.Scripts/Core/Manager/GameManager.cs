using UnityEngine;
using System.Collections.Generic;
using Unity.AI.Navigation;
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
    private NavMeshSurface _navMeshSurface;

    private List<GameObject> weaponObjs = new();

    public List<WeaponDataList> UI_weaponDatas = new();

    [SerializeField] private AnimatorOverrideController _animController;
    public AnimatorOverrideController defalutAnim => _animController;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
        _navMeshSurface = GetComponent<NavMeshSurface>();

    }
    private void Start()
    {
        Setting();
    }
    private void Setting()
    {
        ui_Controller.weaponUI.Open_Panel();
        ReBulidMesh();
    }

    private void Update()
    {
        if (weapons[0] != null && Input.GetKeyDown(KeyCode.Alpha1))
        {
            Select(0);
        }
        else if (weapons[1] != null && Input.GetKeyDown(KeyCode.Alpha2))
        {
            Select(1);
        }
        else if (weapons[2] != null && Input.GetKeyDown(KeyCode.Alpha3))
        {
            Select(2);
        }
        else if (weapons[3] != null && Input.GetKeyDown(KeyCode.Alpha4))
        {
            Select(3);
        }
    }
    #region ÃÑ°ü·Ã
    public void Start_WeaponSetting()
    {
        Select(0);
    }
    private void Select(int idx)
    {
        ui_Controller.interfaceUI.Select_Weapon(idx);
        weaponObjs[idx].SetActive(true);
        weaponObjs.Select(idx, p => p?.SetActive(false));

        Gun swapedGun = weapons[idx] as Gun;
        _playerController.currentWeapon = swapedGun;

        SignalHub.OnChagnedGun?.Invoke(swapedGun);
        SignalHub.OnModifyBulletCount?.Invoke(swapedGun.Ammo, swapedGun.gunData.ammocapacity);
    }

    public void CreateWeapon(string weaponName)
    {
        for (int i = 0; i < 4; i++)
        {
            if (weapons[i] == null)
            {
                Weapon w = WeaponManager.Instance.GetWeapon(weaponName);
                GameObject weapon = Instantiate(w.gameObject, WeaponPos);
                weapon.gameObject.name = weapon.gameObject.name.Replace("(Clone)", "");
                weapons[i] = weapon.GetComponent<Weapon>();
                weaponObjs.Add(weapon);

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
    #endregion
    public void ReBulidMesh()
    {
        _navMeshSurface.BuildNavMesh();
    }
}
