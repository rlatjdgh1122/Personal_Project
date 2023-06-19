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

    public int mapSize = 100;
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
    private void Start()
    {
        StartCreateMap();
        currentSeason = Season.winter;
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
        frontMap.SetTransform(new Vector3(0, 0, CurrentDistance - mapSize));
        frontMap.SetCenterPos(SetCenterPos(frontMap.transform));
        frontMap.SetMap(frontMap);

        frontMap.SpawnTrees(Trees);

        Trees.Shuffle();
        Map map = PoolManager.Instance.Pop("Map") as Map;
        map.SetTransform(new Vector3(0, 0, CurrentDistance));
        map.SetCenterPos(SetCenterPos(map.transform));
        map.SetMap(map);
        map.SpawnTrees(Trees);

        Trees.Shuffle();
        Map BackMap = PoolManager.Instance.Pop("Map") as Map;
        BackMap.SetTransform(new Vector3(0, 0, CurrentDistance + mapSize));
        BackMap.SetCenterPos(SetCenterPos(BackMap.transform));
        BackMap.SetMap(BackMap);


        BackMap.SpawnTrees(Trees);

        GameManager.Instance.ReBulidMesh();
    }
    public void SpawnMaps(float dotValue)
    {
        Debug.Log("SpawnMaps " + dotValue);
        CheckWeater();

        if (dotValue > 0)
        {
            Map frontMap = PoolManager.Instance.Pop("Map") as Map;
            frontMap.SetTransform(new Vector3(0, 0, CurrentDistance + mapSize));
            frontMap.SetCenterPos(SetCenterPos(frontMap.transform));
            frontMap.SetMap(frontMap);

            frontMap.SpawnTrees(Trees);

        }
        else if (dotValue < 0) //뒤로 갔을때
        {
            Map backMap = PoolManager.Instance.Pop("Map") as Map;
            backMap.SetTransform(new Vector3(0, 0, CurrentDistance - mapSize));
            backMap.SetCenterPos(SetCenterPos(backMap.transform));
            backMap.SetMap(backMap);

            backMap.SpawnTrees(Trees);
        }
        GameManager.Instance.ReBulidMesh();
    }

    private int num = 0;
    private void CheckWeater()
    {
        num = Mathf.Abs(CurrentDistance % seasonalCycle);
        switch (num)
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
    private Vector3 SetCenterPos(Transform trm)
    {
        Vector3 boundsSize = trm.localScale; // 크기를 경계 크기로 사용합니다.
        Vector3 max = trm.position + boundsSize / 2f; // 우측 상단 꼭지점 계산
        Vector3 min = trm.position - boundsSize / 2f; // 좌측 하단 꼭지점 계산

        Vector3 centerPos = (max + min) / 2f; // 중심 좌표 계산
        return centerPos;
    }
}
