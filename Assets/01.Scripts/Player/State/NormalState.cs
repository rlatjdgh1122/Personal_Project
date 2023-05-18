using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : CommonState
{
    public override void OnEnterState() //�⺻���·� ���ƿ�����
    {
        _playerMovement.StopImmediately();
        _playerInput.OnMovementKeyPress += OnMoveHandle;
        _playerMovement.IsActiveMove = true;    
    }

    public override void OnExitState() //������
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
