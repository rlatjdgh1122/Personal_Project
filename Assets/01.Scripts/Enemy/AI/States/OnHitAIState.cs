using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitAIState : CommonAIState
{
    public override void OnEnterState()
    {
        _enemyAnimationController.OnEndEventTrigger += AnimationEndHandle;
        _enemyAnimationController.SetHurtTrigger(true);
    }

    public override void OnExitState()
    {
        _enemyAnimationController.OnEndEventTrigger -= AnimationEndHandle;
        _enemyAnimationController.SetHurtTrigger(false);
    }

    private void AnimationEndHandle()
    {
        _aiActionData.IsHit = false;
    }
}
