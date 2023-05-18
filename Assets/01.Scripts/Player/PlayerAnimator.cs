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
    public void SetMoveState(Vector3 value) //움직임 애니메이션
    {
        _animator.SetFloat(_moveXHash, value.x);
        _animator.SetFloat(_moveYHash, value.z);
    }
    public void SetRollingState(bool value)
    {
        _animator.SetBool(_isRollingHash, value);
    }
}
