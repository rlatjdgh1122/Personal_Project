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
        //만약 넉백을 구현할꺼면 여기서 AgentMovement에 active모드를 꺼주고
        // 넉백시키다가 끝나면 꺼주면 된다.
        if (_timer >= _recoverTime)
        {
            _playerController.ChangeState(Core.StateType.Normal);
        }
        return false;
    }
}
