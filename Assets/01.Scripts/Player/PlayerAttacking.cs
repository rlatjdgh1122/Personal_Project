using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttacking : PlayerData
{
    public GameObject weapon;
    protected override void Awake()
    {
        currentWeapon = weapon;
    }
    private void Start()
    {
        Instantiate(currentWeapon.gameObject, Vector3.zero, Quaternion.identity);
    }
    public void Shooting()
    {
        if (currentWeapon.TryGetComponent<Gun>(out Gun gun))
        {
            gun.Shooting();
        }
    }
    public void StopShooting()
    {
        if (currentWeapon.TryGetComponent<Gun>(out Gun gun))
        {
            gun.StopShooting();
        }
    }
}
