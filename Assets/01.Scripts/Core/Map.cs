using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Map : PoolableMono
{
    private List<Transform> Points = new();
    public Vector3 centerPos;

    private void Awake()
    {
        Transform SpawnPoints = transform.Find("Pedestals")?.transform;

        foreach (Transform trm in SpawnPoints)
        {
            Points.Add(trm);
        }
    }
    public void SetCenterPos(Vector3 value)
    {
        centerPos = value;
    }
    public void SetTransform(Vector3 setPos)
    {
        transform.position = new Vector3(0, 0, setPos.z);
    }
    public List<GameObject> trees = new();
    public void SpawnTrees(List<GameObject> seasonTrees)
    {
        for (int i = 0; i < seasonTrees.Count; i++)
        {
            trees.Add(Instantiate(seasonTrees[i], Points[i]));
            trees[i].GetComponent<MeshRenderer>().material = MapManager.Instance.MatKey[MapManager.Instance.currentSeason];

        }
    }
    private void Update()
    {
        Vector3 objectToTarget = GameManager.Instance.playerPos.position - centerPos;
        float num = objectToTarget.z;
        if (Math.Abs(num) >= 50)
        {
            float dot = Vector3.Dot(Vector3.forward.normalized, objectToTarget.normalized);
            if (dot > 0)
            {
                MapManager.Instance.CurrentDistance += MapManager.Instance.mapSize;
            }
            else if (dot < 0)
            {
                MapManager.Instance.CurrentDistance -= MapManager.Instance.mapSize;
            }
            MapManager.Instance.SpawnMaps(dot);
        }
    }

    public override void Init()
    {
        trees.ForEach(p => Destroy(p));
        trees.Clear();
    }
}
