using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
public enum Season
{
    Spring, Summer, Fall, winter
}
public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    [SerializeField]
    private List<GameObject> Trees = new();

    private Transform playerPos;

    public Season currentSeason;
    public Dictionary<Season, Material> MatKey = new();
    public Material[] mats;

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
    private void KeySetting()
    {
        MatKey.Add(Season.winter, mats[0]);
        MatKey.Add(Season.Summer, mats[1]);
        MatKey.Add(Season.Spring, mats[2]);
        MatKey.Add(Season.Fall, mats[3]);
    }

    private void Start()
    {
        playerPos = GameManager.Instance.playerPos;
        currentSeason = Season.Spring;
        SpawnTrees(50);
    }
    public void SpawnTrees(int dis)
    {
        Trees.ForEach(t => { t.GetComponent<Renderer>().material = MatKey[currentSeason]; });

        Map map = PoolManager.Instance.Pop("Map") as Map;
        map.SetTransform(new Vector3(0, 0, CurrentDistance + dis));
        map.SpawnTrees(Trees);

        Map map1 = PoolManager.Instance.Pop("Map") as Map;
        map1.SetTransform(new Vector3(0, 0, CurrentDistance));
        map1.SpawnTrees(Trees);

        Map map2 = PoolManager.Instance.Pop("Map") as Map;
        map2.SetTransform(new Vector3(0, 0, CurrentDistance - dis));
        map2.SpawnTrees(Trees);

        if(dis > 0)
        {
            PoolManager.Instance.Push(map2);
        }
        else if(dis < 0)
        {
            PoolManager.Instance.Push(map);
        }
    }
    public void ChangedSeason(Season nextSeaon)
    {
        currentSeason = nextSeaon;
    }
}
