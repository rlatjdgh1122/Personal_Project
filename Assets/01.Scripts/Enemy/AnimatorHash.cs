using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimatorHash : MonoBehaviour
{
    protected Animator anim;

    protected int MOVE_HASH = Animator.StringToHash("Move");
    protected int SHOOTING_HASH = Animator.StringToHash("Attack");
    protected int ONHIT_HASH = Animator.StringToHash("OnHit");
    protected int DIE_HASH = Animator.StringToHash("Die");
    protected int STUN_HASH = Animator.StringToHash("Stun");

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }


}
