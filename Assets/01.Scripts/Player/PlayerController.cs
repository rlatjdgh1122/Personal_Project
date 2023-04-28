using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour, IPlayerHandle
{
    public PlayerStatData statData;

    public UnityEvent<Vector3,float> OnMovement;
    public UnityEvent<Vector3> OnRotate;
    public UnityEvent OnAttack;

    private Vector3 movePos = Vector3.zero;

    private Animator animator;
    [SerializeField]
    private Camera cam;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
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

    public void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            OnAttack?.Invoke();
        }
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        animator.SetFloat("MoveX", horizontal);
        animator.SetFloat("MoveY", vertical);

        Vector3 movement = new Vector3(horizontal, 0, vertical);
       
        OnMovement?.Invoke(movement, statData.moveSpeed);
    }

    public void WaponSwap()
    {
        throw new System.NotImplementedException();
    }

}
