using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IPlayerHandle
{
    public event Action<Vector3> OnMovementKeyPress = null;
    public event Action OnRollingKeyPress = null;
    public event Action OnFireButtonPress = null; //공격키가 눌렸을때
    public event Action OnFireButtonRelease = null; //공격키를 땠을때
    public event Action OnReloadButtonPress = null; //공격키를 땠을때

    private bool fireButtonDown = false;
    private Vector3 movement;

    void Update()
    {
        Move();
        Attack();
        Rolling();
        Reloading();
    }

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
