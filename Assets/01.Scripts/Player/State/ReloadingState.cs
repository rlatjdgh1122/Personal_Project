using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadingState : CommonState
{
    public override void OnEnterState()
    {
        _playerAnimator.SetReloadingState(true);

        _playerInput.OnMovementKeyPress += OnMoveHandle;
        _playerAnimator.OnAnimationEndTrigger += OnReloadingEndHandle;
    }
    public void OnMoveHandle(Vector3 dir)
    {
        _playerMovement?.SetMovementDirection(dir);
    }
    private void OnReloadingEndHandle()
    {
        Debug.Log("애니메이션 끝");

        _playerController.currentWeapon.Reloading();
        _playerController.ChangeState(StateType.Normal);
    }

    public override void OnExitState()
    {
        _playerAnimator.SetReloadingState(false);
        _playerInput.OnMovementKeyPress -= OnMoveHandle;
    }

    public override bool UpdateState()
    {
        return false;
    }
}
