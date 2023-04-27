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
        SpawnMaps(0);
    }
    public List<Map> maps = new();
    public void SpawnMaps(float dotValue)   
    {
        Trees.ForEach(t => { t.GetComponent<Renderer>().material = MatKey[currentSeason]; });

        Map frontMap = PoolManager.Instance.Pop("Map") as Map;
        frontMap.SetTransform(new Vector3(0, 0, CurrentDistance + 50));
        frontMap.SpawnTrees(Trees);

        Map map = PoolManager.Instance.Pop("Map") as Map;
        map.SetTransform(new Vector3(0, 0, CurrentDistance));
        map.SpawnTrees(Trees);

        Map backMap = PoolManager.Instance.Pop("Map") as Map;
        backMap.SetTransform(new Vector3(0, 0, CurrentDistance - 50));
        backMap.SpawnTrees(Trees);

        if(dotValue > 0) //앞으로 갔을때
        {
            PoolManager.Instance.Push(backMap);
        }
        else if(dotValue < 0) //뒤로 갔을때
        {
            PoolManager.Instance.Push(frontMap);
        }
    }
    public void ChangedSeason(Season nextSeaon)
    {
        currentSeason = nextSeaon;
    }
}
