using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
public class AttackState : CommonState
{
    public override void OnEnterState()
    {
        _playerController.currentWeapon.Shooting();

        _playerInput.OnMovementKeyPress += OnMoveHandle;

        _playerInput.OnFireButtonRelease += _playerController.currentWeapon.StopShooting;
        _playerInput.OnFireButtonRelease += ChangeState;
    }

    public override void OnExitState()
    {
        _playerMovement.StopImmediately();

        _playerInput.OnMovementKeyPress -= OnMoveHandle;

        _playerInput.OnFireButtonRelease -= _playerController.currentWeapon.StopShooting;
        _playerInput.OnFireButtonRelease -= ChangeState;
    }

    private void OnMoveHandle(Vector3 dir)
    {
        _playerMovement?.SetMovementDirection(dir);
    }

    private void ChangeState()
    {
        _playerController.ChangeState(StateType.Normal);
    }
    public override bool UpdateState()
    {
        return false;
    }
}
