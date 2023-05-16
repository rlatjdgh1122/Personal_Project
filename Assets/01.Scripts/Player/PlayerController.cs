using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour, IPlayerHandle
{
    public UnityEvent<Vector3> OnMovement;
    public UnityEvent<Vector3> OnRolling;
    public UnityEvent<Vector3> OnRotate;
    [field: SerializeField] public UnityEvent OnFireButtonPress { get; set; }
    [field: SerializeField] public UnityEvent OnFireButtonRelease { get; set; }

    private Vector3 movement = Vector3.zero;
    private Vector3 movePos = Vector3.zero;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Move();
        LookRotateMouseCursor();
        Attack();
        Rolling();
    }



    private void LookRotateMouseCursor()
    {
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(cameraRay, out hit))
        {
            movePos = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
        }
        OnRotate?.Invoke(movePos);
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(horizontal, 0, vertical);

        OnMovement?.Invoke(movement);
    }
    private void Rolling()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnRolling?.Invoke(movePos);
        }
    }

}
