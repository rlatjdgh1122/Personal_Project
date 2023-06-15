using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemySoData")]
public class EnemySoData : ScriptableObject
{
    public float hp;
    public float speed;
    public float attackDelay;
    public float getExperience; //����ġ ��
}
