using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public PoolListData PoolListData;
    public static GameManager Instance;

    public List<Weapon> weaponDatas = new();

    [SerializeField]
    private Transform _playerPos;
    public Transform playerPos => _playerPos;

    private PlayerController _playerController;
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

        WeaponStatManager.Instance = gameObject.AddComponent<WeaponStatManager>();

        _playerController = _playerPos.GetComponent<PlayerController>();
    }
    private void Start()
    {
        _playerController.currentWeapon = weaponDatas[0];
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _playerController.currentWeapon = weaponDatas[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _playerController.currentWeapon = weaponDatas[1];
        }
    }
}
