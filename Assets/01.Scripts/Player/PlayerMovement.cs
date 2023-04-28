using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    //private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float acceleration = 1f;
    float currentSpeed = 0;
    private void Awake()
    {

    }
    public void Movement(Vector3 movement, float speed)
    {
        currentSpeed = Mathf.Lerp(currentSpeed, speed, acceleration * Time.deltaTime);

        transform.Translate(movement.normalized * currentSpeed * Time.deltaTime, Space.World);
    }
}
