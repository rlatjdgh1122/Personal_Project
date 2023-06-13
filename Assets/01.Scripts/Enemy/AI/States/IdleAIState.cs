using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAIState : CommonAIState //사실상 스턴상태  그냥 가만히 있기 
{
    private float _waitTime;

    public override void OnEnterState()
    {
        _enemyMovement.IsActive = false;
        _enemyAnimationController.SetMove(MOVE_STATE.Idle);
    }

    public override void OnExitState()
    {
        _enemyMovement.IsActive = true;
    }
    public override bool UpdateState()
    {
        return base.UpdateState();
    }
}
