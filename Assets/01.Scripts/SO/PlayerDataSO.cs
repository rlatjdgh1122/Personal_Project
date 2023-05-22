using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerStatData")]
public class PlayerDataSO : ScriptableObject
{
    public float Speed; //������
    public float Hp; //ü��
    public float Stamina; //���¹̳�
    public float Damage; //������
    public float CriticalProbability; //������ ũ��Ƽ�� Ȯ�� ( ũ��Ƽ�� �������� 1.5��
    public float EvasionProbability; //ȸ��Ȯ��
    public Weapon DefaultWeapon; //�⺻ ����
}
