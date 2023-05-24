using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Core.Core;

public class PlayerInput : MonoBehaviour, IPlayerHandle
{
    // public UnityEvent<Vector3> OnRotate;

    public event Action<Vector3> OnMovementKeyPress = null;
    public event Action<Vector3> OnRollingKeyPress = null;
    public event Action OnFireButtonPress = null; //����Ű�� ��������
    public event Action OnFireButtonRelease = null; //����Ű�� ������

    void Update()
    {
        Move();
        Attack();
        Rolling();
        ChangedWeapon();
    }

    private void ChangedWeapon()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1)) GameManager.Instance.SelectWeapon(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) GameManager.Instance.SelectWeapon(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) GameManager.Instance.SelectWeapon(3);
        else if (Input.GetKeyDown(KeyCode.Alpha4)) GameManager.Instance.SelectWeapon(4);*/
    }

    private bool fireButtonDown = false;
    public void Attack()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (fireButtonDown == false)
            {
                fireButtonDown = true;
                OnFireButtonPress?.Invoke();
            }
        }
        else
        {
            if (fireButtonDown == true)
            {
                fireButtonDown = false;
                OnFireButtonRelease?.Invoke();
            }
        }
    }
    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       Vector3 movement = new Vector3(horizontal, 0, vertical);

        OnMovementKeyPress?.Invoke(movement);
    }
    private void Rolling()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnRollingKeyPress?.Invoke(MousePos.normalized);
        }
    }
}