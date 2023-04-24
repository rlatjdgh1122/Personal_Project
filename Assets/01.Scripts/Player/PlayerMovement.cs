using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    public void Movement(Vector3 movement)
    {
        moveDirection.y -= 20 * Time.deltaTime;

        // �̵� ����
        characterController.Move(moveDirection * Time.deltaTime);

        // ĳ���� �̵�
        characterController.Move(movement * Time.deltaTime);
    }
}
