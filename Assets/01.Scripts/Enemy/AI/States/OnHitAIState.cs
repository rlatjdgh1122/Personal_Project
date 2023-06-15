using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitAIState : CommonAIState
{
    public float stunDelay = 1f;
    public float _lastAtkTime = 0;
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
        

        Debug.Log("맞은상태 들어옴");
    }

    public override void OnExitState()
    {
        Debug.Log("맞은상태 나감");
        _enemyAnimationController.OnEndEventTrigger -= AnimationEndHandle;

        _enemyMovement.IsRotate = true;
        _enemyMovement.IsMove = true;

        _enemyAnimationController.SetHurtTrigger(false);
        _enemyAnimationController.SetStun(false);
    }

    private void AnimationEndHandle()
    {
        Debug.Log("애니메이션");
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
                Debug.Log("상태변환");
                _aiActionData.IsHit = false;
            }
        }
        return false;
    }
}
