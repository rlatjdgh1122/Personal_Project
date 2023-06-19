using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class OnHitState : CommonState
{
    private float _timer = 0;
    private float _recoverTime = .3f;

    public override void OnEnterState()
    {
        _timer = 0;
        _playerAnimator.SetHurtTrigger(true);
    }

    private void OnHitEndHandle()
    {
        _playerMovement.StopImmediately();
        _playerController.ChangeState(StateType.Normal);
    }

    public override void OnExitState()
    {
        _playerAnimator.SetHurtTrigger(false);
        _playerAnimator.OnAnimationEndTrigger -= OnHitEndHandle;
    }

    public override bool UpdateState()
    {
        _timer += Time.deltaTime;
        if (_timer >= _recoverTime)
        {
            _playerController.ChangeState(Core.StateType.Normal);
        }
        return false;
    }
}
