using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : PlayerData
{
    public void Movement(Vector3 movement)
    {
        anim.SetFloat("MoveX", movement.x);
        anim.SetFloat("MoveY", movement.z);

        transform.Translate(movement.normalized * MoveSpeed * Time.deltaTime, Space.World);
    }
}
