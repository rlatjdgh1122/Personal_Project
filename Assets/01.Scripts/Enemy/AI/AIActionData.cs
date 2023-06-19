using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionData : MonoBehaviour
{
    public bool TargetSpotted; //���� �߰ߵǾ��°�?
    public Vector3 HitPoint; //���������� ó���� ������ ����ΰ�?
    public Vector3 HitNormal;  //���������� ó���� ������ �븻����
    public Vector3 LastSpotPoint; //���������� �߰ߵ� ������ ����ΰ�?
    public bool IsArrived; //�������� �����ߴ°�?
    public bool IsAttacking; //���� ������ �������ΰ�?
    [field: SerializeField] public bool IsRangeAttacking { get; set; } //���� ���Ÿ������� �������ΰ�?
    [field: SerializeField] public bool IsHit { get; set; } //���� �°��ִ�?
    public void Init()
    {
        TargetSpotted = false;
        IsArrived = false;
        IsAttacking = false;
        IsRangeAttacking = false;
        IsHit = false;
    }
}