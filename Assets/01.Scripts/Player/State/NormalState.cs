using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : CommonState
{
    public override void OnEnterState() //기본상태로 돌아왔을때
    {
        _playerMovement.StopImmediately();
        _playerInput.OnMovementKeyPress += OnMoveHandle;
        _playerMovement.IsActiveMove = true;    
    }

    public override void OnExitState() //나갈때
    {
        _playerMovement.StopImmediately();
        _playerInput.OnMovementKeyPress -= OnMoveHandle;
        _playerMovement.IsActiveMove = false;
    }

    public override bool UpdateState()
    {
        return false;
    }
    public void OnMoveHandle(Vector3 dir)
    {
        _playerMovement?.SetMovementVelocity(dir);
        
    }
}
