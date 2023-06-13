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
    public void SetMove(MOVE_STATE value)
    {

        if (value == MOVE_STATE.Idle)
            anim.SetFloat(MOVE_HASH, 0);

        if (value == MOVE_STATE.Walk)
            anim.SetFloat(MOVE_HASH, .5f);

        if (value == MOVE_STATE.Run)
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
    public void SetShooting(bool value)
    {
        if (value)
            anim.SetTrigger(SHOOTING_HASH);
        else 
            anim.ResetTrigger(SHOOTING_HASH);
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
}
