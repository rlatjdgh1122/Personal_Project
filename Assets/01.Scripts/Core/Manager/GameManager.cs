using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Core;
public class GameManager : MonoBehaviour
{
    public PoolListData PoolListData;
    public static GameManager Instance;
    public PlayerInitStatData PlayerInitStatData;
    [SerializeField]
    private Transform _playerPos;
    public Transform playerPos => _playerPos;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this);

        PoolManager.Instance = new PoolManager(transform);
        PoolListData.poolData.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.count));

        PlayerData.InitPlayerStatSetting(PlayerInitStatData);
    }
}
