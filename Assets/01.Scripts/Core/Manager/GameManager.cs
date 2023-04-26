using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PoolListData PoolListData;
    public static GameManager Instance;

    [SerializeField]
    private Transform _playerPos;
    public Transform playerPos => _playerPos;
    
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else Destroy(this);

        PoolManager.Instance = new PoolManager(transform);
        PoolListData.poolData.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.count));
    }
}
