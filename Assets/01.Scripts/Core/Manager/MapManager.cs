using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
public enum Season
{
    Spring, Summer, Fall, winter
}
public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    public int seasonalCycle;
    public Season currentSeason;
    public Material[] mats;
    [SerializeField]
    private List<GameObject> Trees = new();

    public Dictionary<Season, Material> MatKey = new();

    private int Distance = 0;
    public int CurrentDistance
    {
        get { return Distance; }
        set { Distance = value; }
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this);

        KeySetting();
    }
    public List<Map> maps = new();
    private void Start()
    {
        currentSeason = Season.winter;

        StartCreateMap();
    }
    private void KeySetting()
    {
        MatKey.Add(Season.winter, mats[0]);
        MatKey.Add(Season.Summer, mats[1]);
        MatKey.Add(Season.Spring, mats[2]);
        MatKey.Add(Season.Fall, mats[3]);
    }
    private void StartCreateMap()
    {
        Trees.Shuffle();
        Map frontMap = PoolManager.Instance.Pop("Map") as Map;
        frontMap.SetTransform(new Vector3(0, 0, CurrentDistance - 50));
        frontMap.SpawnTrees(Trees);
        maps.Add(frontMap);

        Trees.Shuffle();
        Map map = PoolManager.Instance.Pop("Map") as Map;
        map.SetTransform(new Vector3(0, 0, CurrentDistance));
        map.SpawnTrees(Trees);
        maps.Add(map);

        Trees.Shuffle();
        Map BackMap = PoolManager.Instance.Pop("Map") as Map;
        BackMap.SetTransform(new Vector3(0, 0, CurrentDistance + 50));
        BackMap.SpawnTrees(Trees);
        maps.Add(BackMap);
    }
    public void SpawnMaps(float dotValue)
    {
        CheckWeater();

        if (dotValue > 0) //앞으로 갔을때
        {
            PoolManager.Instance.Push(maps[0]);
            maps.Remove(maps[0]);

            Map frontMap = PoolManager.Instance.Pop("Map") as Map;
            frontMap.SetTransform(new Vector3(0, 0, CurrentDistance + 50));
            frontMap.SpawnTrees(Trees);
            maps.Add(frontMap);

        }
        else if (dotValue < 0) //뒤로 갔을때
        {
            PoolManager.Instance.Push(maps[maps.Count - 1]);
            maps.Remove(maps[maps.Count - 1]);

            Map backMap = PoolManager.Instance.Pop("Map") as Map;
            backMap.SetTransform(new Vector3(0, 0, CurrentDistance - 50));
            backMap.SpawnTrees(Trees);
            maps.Insert(0, backMap);
        }
    }

    private void CheckWeater()
    {
        switch (Distance / (seasonalCycle * 50))
        {
            case 1: ChangedSeason(Season.winter); break;
            case 2: ChangedSeason(Season.Summer); break;
            case 3: ChangedSeason(Season.Spring); break;
            case 4: ChangedSeason(Season.Fall); break;
        }
    }

    public void ChangedSeason(Season nextSeaon)
    {
        currentSeason = nextSeaon;
    }
}
