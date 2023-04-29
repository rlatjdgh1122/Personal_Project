using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/weaponData")]
public class WeaponData : ScriptableObject
{
    public float attackSpeed;
    public float weight;
    public AudioClip shootSound;
    public AnimatorOverrideController animController;
}
