using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadingState : CommonState
{
    private float _animationThreshold = .5f; //�ִϸ��̼� �ð�
    private float _timer = 0;
    public override void OnEnterState()
    {
        Debug.Log("����");
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
        if (_timer < _animationThreshold) return;
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
        _timer += Time.deltaTime;
        return false;
    }
}
