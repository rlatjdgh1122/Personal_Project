using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Map : PoolableMono
{
    private List<Transform> Points = new();

    private List<GameObject> Trees = new();
    private void Awake()
    {
        Transform SpawnPoints = transform.Find("Pedestal")?.transform;

        foreach (Transform trm in SpawnPoints)
        {
            Points.Add(trm);
        }
    }
    public void SpawnTrees(List<GameObject> seasonTrees)
    {
        for (int i = 0; i < seasonTrees.Count; i++)
        {
            GameObject obj = Instantiate(seasonTrees[i], Points[i]);
            Trees.Add(obj);
        }
    }
    public override void Init()
    {
        Trees.Clear();
    }
}
