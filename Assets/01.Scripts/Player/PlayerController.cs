using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : PlayerData, IPlayerHandle
{
    public UnityEvent<Vector3> OnMovement;
    public UnityEvent<Vector3> OnRotate;
    public UnityEvent OnAttack;

    private Vector3 movePos = Vector3.zero;
    [SerializeField]
    private Camera cam;

    void Update()
    {
        Move();
        LookRotateMouseCursor();
        Attack();
        AttackCoolTime();
    }
    private bool isAttack = true;
    private float time = 0;
    private void AttackCoolTime()
    {
        if (isAttack == false)
        {
            time += Time.deltaTime;
            if (time >= currentWeaponData?.attackSpeed)
            {
                isAttack = true;
                time = 0;
            }
        }
    }

    private void LookRotateMouseCursor()
    {
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(cameraRay, out hit))
            movePos = new Vector3(hit.point.x, transform.position.y, hit.point.z) -
                transform.position;

        OnRotate?.Invoke(movePos);
    }

    public void Attack()
    {
        if (Input.GetMouseButton(0) && isAttack &&
            currentWeaponData != null)
        {
            isAttack = false;
            OnAttack?.Invoke();
        }
    }
    
    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        OnMovement?.Invoke(movement);
    }

    public void WaponSwap()
    {
        throw new System.NotImplementedException();
    }

}
