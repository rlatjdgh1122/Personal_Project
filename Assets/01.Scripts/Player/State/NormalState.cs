using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
public class NormalState : CommonState
{
    public override void OnEnterState() //�⺻���·� ���ƿ�����
    {
        _playerMovement.StopImmediately();
        _playerMovement.IsActiveMove = true;

        _playerInput.OnMovementKeyPress += OnMoveHandle;
        _playerInput.OnFireButtonPress += OnFireButtonPressHandle;
        _playerInput.OnRollingKeyPress += OnRollingHandle;
        _playerInput.OnReloadButtonPress += OnReloadingHandle;
    }

    private void OnReloadingHandle()
    {
        _playerController?.ChangeState(StateType.Reloading);
    }

    public override void OnExitState() //������
    {
        _playerInput.OnMovementKeyPress -= OnMoveHandle;
        _playerInput.OnFireButtonPress -= OnFireButtonPressHandle;
        _playerInput.OnRollingKeyPress -= OnRollingHandle;
    }
    private void OnFireButtonPressHandle()
    {
        if (_playerController.currentWeapon != null)
            _playerController?.ChangeState(StateType.Attack);
    }
    private void OnRollingHandle()
    {
        _playerController?.ChangeState(StateType.Rolling);
    }
    public void OnMoveHandle(Vector3 dir)
    {
        _playerMovement?.SetMovementDirection(dir);

    }
    public override bool UpdateState()
    {
        return false;
    }
}
