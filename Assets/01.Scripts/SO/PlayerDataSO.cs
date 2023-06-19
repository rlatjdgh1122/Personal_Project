using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerStatData")]
public class PlayerDataSO : ScriptableObject
{
    [Range(5,8)]
    public float Speed; //움직임
    [Range(80,150)]
    public int Hp; //체력
    [Range(100,150)]
    public int Stamina; //스태미나
    [Range(30,50)]
    public float Damage; //데미지
    [Range(10,25)]
    public float CriticalProbability; //데미지 크리티컬 확률 ( 크리티컬 데미지는 1.5배
    [Range(10,15)]
    public float EvasionProbability; //회피확률
}