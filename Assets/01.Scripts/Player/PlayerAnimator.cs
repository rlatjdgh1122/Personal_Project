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
    public void SetMoveState(Vector3 value) //������ �ִϸ��̼�
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
    public event Action OnAnimationEndTrigger = null; //�ִϸ��̼��� ����ɶ����� Ʈ���� �Ǵ� �̺�Ʈ��.
    public event Action OnAnimationEventTrigger = null; //�ִϸ��̼� ���� �̺�Ʈ Ʈ����
    public event Action OnPreAnimationEventTrigger = null; //���� �ִϸ��̼� Ʈ����

    public void OnAnimationEnd() //�ִϸ��̼��� ����Ǹ� �̰� ����ȴ�.
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
