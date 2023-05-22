using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerStatData")]
public class PlayerDataSO : ScriptableObject
{
    public float Speed; //움직임
    public float Hp; //체력
    public float Stamina; //스태미나
    public float Damage; //데미지
    public float CriticalProbability; //데미지 크리티컬 확률 ( 크리티컬 데미지는 1.5배
    public float EvasionProbability; //회피확률
    public Weapon DefaultWeapon; //기본 무기
}
