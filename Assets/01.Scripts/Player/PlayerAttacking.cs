using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttacking : PlayerData
{
    public GameObject q;
    private void Start()
    {
        Instantiate(q, Vector3.zero, Quaternion.identity);
    }
    public void Shooting()
    {
        if (q.TryGetComponent<Gun>(out Gun gun))
        {
            gun.Shooting();
        }
    }
    public void StopShooting()
    {
        if (q.TryGetComponent<Gun>(out Gun gun))
        {
            gun.StopShooting();
        }
    }
}
