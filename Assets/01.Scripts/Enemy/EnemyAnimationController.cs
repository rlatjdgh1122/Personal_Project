using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MOVE_STATE
{
    Idle,
    Walk,
    Run,
}
public class EnemyAnimationController : AnimatorHash
{
    public event Action OnEndEventTrigger = null;
    public event Action OnStartEventTrigger = null;
    public event Action OnPreEventTrigger = null;
    public event Action OnPreEndEventTrigger = null;
    public void SetMove(MOVE_STATE value)
    {

        if (value == MOVE_STATE.Idle)
            anim.SetFloat(MOVE_HASH, 0);

        else if (value == MOVE_STATE.Walk)
            anim.SetFloat(MOVE_HASH, .5f);

        else if (value == MOVE_STATE.Run)
            anim.SetFloat(MOVE_HASH, 1);

    }
    public void SetAttack(bool value)
    {
        if (value)
        {
            anim.SetTrigger(SHOOTING_HASH);
        }
        else
        {
            anim.ResetTrigger(SHOOTING_HASH);
        }
    }
    public void SetStun(bool value)
    {
        if (value == true)
            anim.SetBool(STUN_HASH, true);
        else if (value == false)
            anim.SetBool(STUN_HASH, false);
    }
    public void Die()
    {
        anim.SetTrigger(DIE_HASH);
    }
    public void SetShooting(bool value)
    {
        if (value)
            anim.SetTrigger(SHOOTING_HASH);
        else
            anim.ResetTrigger(SHOOTING_HASH);
    }
    public void SetHurtTrigger(bool value)
    {
        if (value)
            anim.SetTrigger(ONHIT_HASH);
        else
            anim.ResetTrigger(ONHIT_HASH);
    }
    private void OnEndEvent()
    {
        OnEndEventTrigger?.Invoke();
    }
    private void OnStartEvent()
    {
        OnStartEventTrigger?.Invoke();
    }
    private void OnPreEvent()
    {
        OnPreEventTrigger?.Invoke();
    }
    private void OnPreEndEvent()
    {
        OnPreEndEventTrigger?.Invoke();
    }
}
