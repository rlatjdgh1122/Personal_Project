using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    //private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    public void Movement(Vector3 movement, float speed)
    {
       // movement.y += -9.8f * Time.deltaTime;

       //rigid.MovePosition(movement * speed * Time.deltaTime);
    }
}
