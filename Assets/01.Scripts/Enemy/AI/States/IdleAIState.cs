using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAIState : CommonAIState
{
    public override void OnEnterState()
    {
        _enemyMovement.StartImmediately();
        _enemyMovement.IsRotate = true;
        _enemyAnimationController.SetMove(MOVE_STATE.Idle);
    }

    public override void OnExitState()
    {

    }
    public override bool UpdateState()
    {
        return base.UpdateState();
    }
}
