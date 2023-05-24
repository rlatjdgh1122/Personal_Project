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
        _playerInput.OnMovementKeyPress += OnRollingHandle;
        _playerMovement.IsActiveMove = true;

        _playerAnimator.Animator.applyRootMotion = true;

        _playerAnimator.OnAnimationEndTrigger += OnRollingEndHandle;
        _playerAnimator.SetRollingState(true);

        _timer = 0;
    }


    public override void OnExitState()
    {
        _playerMovement.StopImmediately();
        _playerInput.OnMovementKeyPress -= OnRollingHandle;
        _playerMovement.IsActiveMove = false;

        _playerAnimator.Animator.applyRootMotion = false;

        _playerAnimator.OnAnimationEndTrigger -= OnRollingEndHandle;
        _playerAnimator.SetRollingState(false);
    }
    private void OnRollingHandle(Vector3 dir)
    {
        _playerMovement?.SetMovementDirection(dir);
        transform.rotation = Quaternion.LookRotation(dir);
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
