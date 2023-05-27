using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingState : CommonState
{
    [SerializeField]
    private float _animationThreshold = .1f; //애니메이션 시간

    private float _timer = 0;

    public override void OnEnterState()
    {
        _playerMovement.StopImmediately();
        _playerInput.OnRollingKeyPress += OnRollingHandle;
        //_playerMovement.IsActiveMove = false;
        _playerAnimator.OnAnimationEndTrigger += OnRollingEndHandle;
        _playerAnimator.SetRollingState(true);
        _timer = 0;
    }


    public override void OnExitState()
    {
        _playerMovement.StopImmediately();
        _playerInput.OnRollingKeyPress -= OnRollingHandle;
        //_playerMovement.IsActiveMove = false;
        _playerAnimator.OnAnimationEndTrigger -= OnRollingEndHandle;
        _playerAnimator.SetRollingState(false);
    }
    private void OnRollingHandle(Vector3 dir)
    {
        Debug.Log("0qer");
        _playerMovement?.SetMovementDirection(dir);
        _playerMovement?.PlayerToRoll();
    }

    private void OnRollingEndHandle()
    {
        if (_timer < _animationThreshold) return;
        _playerMovement.StopImmediately();
        _playerController.ChangeState(StateType.Normal);
    }
    public override bool UpdateState()
    {
        _timer += Time.deltaTime;
        return false;
    }
}
