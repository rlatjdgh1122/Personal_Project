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

    private void OnCollisionEnter()
    {
        Vector3 topRight = transform.position + new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, 0);
        Vector3 bottomLeft = transform.position + new Vector3(-transform.localScale.x / 2, -transform.localScale.y / 2, 0);

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
            Debug.Log(centerPos);
            float dot = Vector3.Dot(Vector3.forward.normalized, objectToTarget.normalized);
            Debug.Log("내적 값 : " + dot);
            if (dot > 0)
            {
                MapManager.Instance.CurrentDistance += 50;
            }
            else if (dot < 0)
            {
                MapManager.Instance.CurrentDistance -= 50;
            }
            MapManager.Instance.SpawnMaps(dot);
        }
    }
    public override void Init()
    {
        Debug.Log("초기화~");
    }
}
