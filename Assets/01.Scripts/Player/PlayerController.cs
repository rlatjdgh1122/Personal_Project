using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour, IPlayerHandle
{
    public PlayerStatData statData;

    public UnityEvent<float> OnMovement;
    private void Awake()
    {
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        OnMovement?.Invoke(statData.moveSpeed);
    }

    public void WaponSwap()
    {
        throw new System.NotImplementedException();
    }

}
