using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : PlayerAnimatorable
{
    private Animator _animator;
    public Animator Animator => _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
}