using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimator : PlayerAnimatorable
{
    public RuntimeAnimatorController die_animator;
    private Animator _animator;
    public Animator Animator => _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void SetHurtTrigger(bool value)
    {
        if (value)
            _animator.SetTrigger(_hurtTriggerHash);
        else
            _animator.ResetTrigger(_hurtTriggerHash);
    }
    public void SetMoveState(Vector3 value) //움직임 애니메이션
    {
        _animator.SetFloat(_moveXHash, value.x);
        _animator.SetFloat(_moveYHash, value.z);
    }
    public void SetRollingState(bool value)
    {
        _animator.SetBool(_isRollingHash, value);
    }
    public void SetShootingState(bool value)
    {
        _animator.SetBool(_isShootingHash, value);
    }
    public void SetReloadingState(bool value)
    {
        if (value == true)
            _animator.SetTrigger(_isReloadingHash);
        else
            _animator.ResetTrigger(_isReloadingHash);
    }
    public event Action OnAnimationEndTrigger = null; //애니메이션이 종료될때마다 트리거 되는 이벤트임.
    public event Action OnAnimationEventTrigger = null; //애니메이션 내의 이벤트 트리거
    public event Action OnPreAnimationEventTrigger = null; //전조 애니메이션 트리거

    public void OnAnimationEnd() //애니메이션이 종료되면 이게 실행된다.
    {
        OnAnimationEndTrigger?.Invoke();
    }

    public void OnAnimationEvent()
    {
        OnAnimationEventTrigger?.Invoke();
    }

    public void OnPreAnimationEvent()
    {
        OnPreAnimationEventTrigger?.Invoke();
    }

#if UNITY_EDITOR
    public void SetDead()
    {
        _animator.runtimeAnimatorController = die_animator;
    }
#endif
    private void EndDeadAnim()
    {
        SceneManager.LoadScene(3);
    }
}
