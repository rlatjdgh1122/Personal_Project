using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour, IPlayerHandle
{
    public PlayerStatData statData;

    public UnityEvent<Vector3> OnMovement;
    public UnityEvent<Vector3> OnRotate;

    private Vector3 movePos = Vector3.zero;

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
    }

    private void Rotation()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointTolook = cameraRay.GetPoint(rayLength);

            movePos = new Vector3(pointTolook.x, transform.position.y, pointTolook.z);
        }
        OnRotate?.Invoke(movePos);
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        animator.SetFloat("MoveX", horizontal);
        animator.SetFloat("MoveY", vertical);

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        movement *= statData.moveSpeed;
        OnMovement?.Invoke(movement);
    }

    public void WaponSwap()
    {
        throw new System.NotImplementedException();
    }

}
