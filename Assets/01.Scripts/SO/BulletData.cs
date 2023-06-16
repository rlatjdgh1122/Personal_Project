using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/BulletData")]
public class BulletData : ScriptableObject
{
    public float lifeTime;
    public float speed;
    public GameObject hitParticle;
}
