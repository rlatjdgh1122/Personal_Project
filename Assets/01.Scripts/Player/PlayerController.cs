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
    [field: SerializeField] public UnityEvent OnFireButtonPress { get; set; }
    [field: SerializeField] public UnityEvent OnFireButtonRelease { get; set; }

    private bool fireButtonDown = false;
    public void Attack()
    {
        if (Input.GetAxisRaw("Fire1") > 0 && currentWeaponData != null)
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
