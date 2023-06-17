using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnHitAIState : CommonAIState
{
    public float stunDelay = 1f;
    public float _lastAtkTime = 0;
    public UnityEvent onHitAction = null;

    public void SetStunDelay(float value)
    {
        stunDelay = value;
    }
    public override void OnEnterState()
    {
        _enemyAnimationController.OnEndEventTrigger += AnimationEndHandle;

        _enemyMovement.IsRotate = false;
        _enemyMovement.IsMove = false;

        _enemyAnimationController.SetHurtTrigger(true);
        onHitAction?.Invoke();
    }

    public override void OnExitState()
    {
        _enemyAnimationController.OnEndEventTrigger -= AnimationEndHandle;

        _enemyMovement.IsRotate = true;
        _enemyMovement.IsMove = true;

        _enemyAnimationController.SetHurtTrigger(false);
        _enemyAnimationController.SetStun(false);
    }

    private void AnimationEndHandle()
    {
        _enemyAnimationController.SetStun(true);
        _lastAtkTime = Time.time;
    }
    public override bool UpdateState()
    {
        if (base.UpdateState())
            return true;

        if (_aiActionData.IsHit == true)
        {
            if (_lastAtkTime + stunDelay < Time.time)
            {
                _aiActionData.IsHit = false;
            }
        }
        return false;
    }
}
