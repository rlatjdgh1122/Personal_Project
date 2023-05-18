using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAnimatorable : MonoBehaviour
{
    protected readonly int _moveXHash = Animator.StringToHash("MoveX");
    protected readonly int _moveYHash = Animator.StringToHash("MoveY");

    protected readonly int _isRollingHash = Animator.StringToHash("Rolling");

}
