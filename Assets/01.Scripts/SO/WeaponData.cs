using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/weaponData")]
public class WeaponData : ScriptableObject
{
    public float damage;
    public float attackDelay;
    public float knockBack;
    public float weight;
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AnimatorOverrideController animController;
}
