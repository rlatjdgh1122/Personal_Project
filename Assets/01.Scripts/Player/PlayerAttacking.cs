using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Core.Core;
public class PlayerAttacking : MonoBehaviour
{
    public void StopShooting()
    {
        if (gameObject.TryGetComponent<Gun>(out Gun gun))
        {
            gun.StopShooting();
        }
    }
}
