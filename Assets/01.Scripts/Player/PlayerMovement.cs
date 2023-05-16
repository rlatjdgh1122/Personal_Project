using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static Core.Core;

public class PlayerMovement : MonoBehaviour
{
    public void Movement(Vector3 movement)
    {
        Anim.SetFloat("MoveX", movement.x);
        Anim.SetFloat("MoveY", movement.z);

        transform.Translate(movement * MoveSpeed * Time.deltaTime, Space.World);
    }
    public void Roll(Vector3 direction)
    {
        Anim.SetTrigger("Rolling");

        transform.Translate(direction * MoveSpeed * Time.deltaTime, Space.World);
    }
}
