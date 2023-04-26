using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Season
{
    Spring, Summer, Fall, winter
}
public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    [SerializeField]
    private List<GameObject> Trees = new();

    private Transform playerPos;

    public Season currentSeason;
    public Dictionary<Season, Material> MatKey = new();
    public Material[] mats;
    /*    private readonly string SpringTxt = "Textures/Spring";
        private readonly string SummerTxt = "Textures/Summer";
        private readonly string FallTxt = "Textures/Fall";
        private readonly string WinterTxt = "Textures/Winter";*/
    void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);

       // playerPos = GameManager.Instance.playerPos;

        KeySetting();
    }

    private void KeySetting()
    {
        MatKey.Add(Season.winter, mats[0]);
        MatKey.Add(Season.Summer, mats[1]);
        MatKey.Add(Season.Spring, mats[2]);
        MatKey.Add(Season.Fall,   mats[3]);
    }

    private void Start()
    {
        currentSeason = Season.Spring;
        SpawnTrees(Trees, currentSeason);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangedSeason(Season.Fall);
            SpawnTrees(Trees, currentSeason);
        }
    }
    public void SpawnTrees(List<GameObject> seasonTrees, Season season)
    {
        seasonTrees.Shuffle();

        seasonTrees.ForEach(t => { t.GetComponent<Renderer>().material = MatKey[season]; });
        Map map = PoolManager.Instance.Pop("Map") as Map;
        map.SpawnTrees(seasonTrees);
    }
    public void ChangedSeason(Season nextSeaon)
    {
        currentSeason = nextSeaon;
    }
}
