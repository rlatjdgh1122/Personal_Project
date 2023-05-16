using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Core.Core;
public class PlayerAttacking : MonoBehaviour
{
    public GameObject weapon;
    public Transform gunPivot;
    private Gun gun;
    private void Start()
    {
        Instantiate(currentWeapon.gameObject, gunPivot);
        gun = currentWeapon.GetComponent<Gun>();
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
