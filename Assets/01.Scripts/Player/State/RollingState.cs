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
        _playerAnimator.SetRollingState(true);
        _playerAnimator.OnAnimationEndTrigger += OnRollingEndHandle;
        _playerMovement?.PlayerToRoll();
        _timer = 0;
    }


    public override void OnExitState()
    {
        _playerAnimator.SetRollingState(false);
        _playerAnimator.OnAnimationEndTrigger -= OnRollingEndHandle;

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
