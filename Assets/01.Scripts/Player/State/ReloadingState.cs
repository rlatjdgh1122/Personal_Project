using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadingState : CommonState
{
    private float _animationThreshold = .5f; //애니메이션 시간
    private float _timer = 0;
    public override void OnEnterState()
    {
        _playerAnimator.SetReloadingState(true);

        _playerInput.OnMovementKeyPress += OnMoveHandle;
        _playerAnimator.OnPreAnimationEventTrigger += ReloadSound;
        _playerAnimator.OnAnimationEndTrigger += OnReloadingEndHandle;
    }

    private void ReloadSound()
    {
        SoundManager.Instance.PlayerSoundName("장전");
    }

    public void OnMoveHandle(Vector3 dir)
    {
        _playerMovement?.SetMovementDirection(dir);
    }
    private void OnReloadingEndHandle()
    {
        if (_timer < _animationThreshold) return;
        Gun curGun = _playerController.currentWeapon;
        curGun.Reloading();
        _playerController.ChangeState(StateType.Normal);
    }

    public override void OnExitState()
    {
        _playerAnimator.SetReloadingState(false);
        _playerInput.OnMovementKeyPress -= OnMoveHandle;
        _playerAnimator.OnPreAnimationEventTrigger -= ReloadSound;
        _playerAnimator.OnAnimationEndTrigger -= OnReloadingEndHandle;
    }

    public override bool UpdateState()
    {
        _timer += Time.deltaTime;
        return false;
    }
}
