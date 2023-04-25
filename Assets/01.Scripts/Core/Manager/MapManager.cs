using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WheatherTrees
{
    public List<GameObject> SpringTrees;
    public List<GameObject> SummerTrees;
    public List<GameObject> FallTrees;
    public List<GameObject> WinterTrees;
}
public enum Season
{
    Spring, Summer, Fall, winter
}
public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    [SerializeField]
    private WheatherTrees TreeList = new();

    private Transform playerPos;

    public Season currentSeason;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);

        playerPos = GameManager.Instance.playerPos;
    }
    private void Start()
    {
        currentSeason = Season.Spring;
        SeasonToTree(currentSeason);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangedSeason(Season.Summer);
            SeasonToTree(currentSeason);
        }
    }
    public void SeasonToTree(Season season)
    {
        switch (season)
        {
            case Season.Spring:
                SpawnTrees(TreeList.SpringTrees);
                break;
            case Season.Summer:
                SpawnTrees(TreeList.SummerTrees);
                break;
            case Season.Fall:
                SpawnTrees(TreeList.FallTrees);
                break;
            case Season.winter:
                SpawnTrees(TreeList.WinterTrees);
                break;
        }
    }
    public void SpawnTrees(List<GameObject> seasonTrees)
    {
        Map map = PoolManager.Instance.Pop("Map") as Map;
        map.SpawnTrees(seasonTrees);
    }
    public void ChangedSeason(Season nextSeaon)
    {
        currentSeason = nextSeaon;
    }
}
