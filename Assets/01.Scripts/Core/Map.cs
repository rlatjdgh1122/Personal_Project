using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Map : PoolableMono
{
    private List<Transform> Points = new();
    private Vector3 centerPos;
    private void Awake()
    {
        Transform SpawnPoints = transform.Find("Pedestal")?.transform;

        foreach (Transform trm in SpawnPoints)
        {
            Points.Add(trm);
        }
    }

    private void Start()
    {
        Vector3 topLeft = transform.position + new Vector3(-transform.localScale.x / 2, transform.localScale.y / 2, 0);
        Vector3 topRight = transform.position + new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, 0);
        Vector3 bottomLeft = transform.position + new Vector3(-transform.localScale.x / 2, -transform.localScale.y / 2, 0);
        Vector3 bottomRight = transform.position + new Vector3(transform.localScale.x / 2, -transform.localScale.y / 2, 0);

        Vector3 diagonal = topRight - bottomLeft;

        // 대각선 벡터의 중심점을 쿼드의 중심 위치로 사용합니다.
        centerPos = (topRight + bottomLeft) / 2;
    }
    public void SetTransform(Vector3 setPos)
    {
        transform.position = new Vector3(0, 0, setPos.z);
    }
    public void SpawnTrees(List<GameObject> seasonTrees)
    {
        seasonTrees.Shuffle();

        for (int i = 0; i < seasonTrees.Count; i++)
        {
            GameObject obj = Instantiate(seasonTrees[i], Points[i]);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("맵밖으로 나감");

            Vector3 objectToTarget = collision.transform.position - centerPos; // 게임 오브젝트에서 특정 위치까지의 벡터를 계산합니다.
            float dot = Vector3.Dot(Vector3.forward, objectToTarget);

            int dis = 0;
            Debug.Log("내적 값 : " + dot);
            if (dot > 0)
            {
                dis += 50;
            }
            else if (dot < 0)
            {
                dis -= 50;
            }
            MapManager.Instance.CurrentDistance += dis;

            PoolManager.Instance.Push(this);

            MapManager.Instance.SpawnTrees(dis);
        }
    }
    // center + 25
    // center - 25
    // player z
    public override void Init()
    {

    }
}
