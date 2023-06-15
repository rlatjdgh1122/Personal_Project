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
    private void Start() //간격은 50
    {
        Vector3 topRight = transform.position + new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, 0);
        Vector3 bottomLeft = transform.position + new Vector3(-transform.localScale.x / 2, -transform.localScale.y / 2, 0);

        centerPos = (topRight + bottomLeft) / 2;

        Debug.Log("센터 : " + centerPos);
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
    private bool isOne = false;
    private void Update()
    {
        Vector3 objectToTarget = GameManager.Instance.playerPos.position - centerPos;

        Debug.Log(objectToTarget);
        float num = objectToTarget.z;
        if (Math.Abs(num) >= 50)
        {
            if (isOne == false)
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

                isOne = true;
            }
        }

    }
    /*  private void OnCollisionExit(Collision collision)
      {
          if (collision.gameObject.CompareTag("Player"))
          {
              Vector3 objectToTarget = collision.transform.position - centerPos;
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
      }*/
    public override void Init()
    {
        trees.ForEach(p => Destroy(p));
        trees.Clear();
    }
}
