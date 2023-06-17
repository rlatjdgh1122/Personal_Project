using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemySoData")]
public class EnemySoData : ScriptableObject
{
    public int hp;
    public int damage;
    public float speed;
    public float rotationSpeed;
    public float attackDelay;
    public float getExperience; //����ġ ��
}
