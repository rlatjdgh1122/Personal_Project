using System;
using UnityEngine;
using static Core.Core;

public class PlayerInput : MonoBehaviour, IPlayerHandle
{
    public event Action<Vector3> OnMovementKeyPress = null;
    public event Action OnRollingKeyPress = null;
    public event Action OnFireButtonPress = null; //공격키가 눌렸을때
    public event Action OnFireButtonRelease = null; //공격키를 땠을때
    public event Action OnReloadButtonPress = null; //공격키를 땠을때

    void Update()
    {
        Move();
        Attack();
        Rolling();
        ChangedWeapon();
        Reloading();
    }

    private void ChangedWeapon()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1)) GameManager.Instance.SelectWeapon(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) GameManager.Instance.SelectWeapon(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) GameManager.Instance.SelectWeapon(3);
        else if (Input.GetKeyDown(KeyCode.Alpha4)) GameManager.Instance.SelectWeapon(4);*/
    }

    private bool fireButtonDown = false;
    private Vector3 movement;

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

        OnMovementKeyPress?.Invoke(movement);
    }
    private void Rolling()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnRollingKeyPress?.Invoke();
        }
    }
    private void Reloading()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnReloadButtonPress?.Invoke();
        }
    }
}
