using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolData
{
    public PoolableMono prefab;
    public int count;
}

[CreateAssetMenu(menuName = "SO/List/PoolList")]
public class PoolListData : ScriptableObject
{
    public List<PoolData> poolData;
}
