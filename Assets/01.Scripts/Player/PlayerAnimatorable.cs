using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAnimatorable : MonoBehaviour
{
    protected readonly int _moveXHash = Animator.StringToHash("MoveX");
    protected readonly int _moveYHash = Animator.StringToHash("MoveY");

    protected readonly int _isRollingHash = Animator.StringToHash("Rolling");

    protected readonly int _isShootingHash = Animator.StringToHash("Shooting");
    protected readonly int _isReloadingHash = Animator.StringToHash("Reloading");

    protected readonly int _hurtTriggerHash = Animator.StringToHash("Hit");
    protected readonly int _DeadHash = Animator.StringToHash("Die");

}