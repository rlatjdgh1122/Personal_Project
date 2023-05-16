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

        transform.Translate(movement * MoveSpeed * Time.deltaTime, Space.World);
    }
    public void Roll(Vector3 direction)
    {
        anim.SetTrigger("Rolling");

        transform.Translate(direction * MoveSpeed * Time.deltaTime, Space.World);
    }
}
