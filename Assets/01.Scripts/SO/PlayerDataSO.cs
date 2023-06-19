using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerStatData")]
public class PlayerDataSO : ScriptableObject
{
    [Range(5,8)]
    public float Speed; //������
    [Range(80,150)]
    public int Hp; //ü��
    [Range(100,150)]
    public int Stamina; //���¹̳�
    [Range(30,50)]
    public float Damage; //������
    [Range(10,25)]
    public float CriticalProbability; //������ ũ��Ƽ�� Ȯ�� ( ũ��Ƽ�� �������� 1.5��
    [Range(10,15)]
    public float EvasionProbability; //ȸ��Ȯ��
}