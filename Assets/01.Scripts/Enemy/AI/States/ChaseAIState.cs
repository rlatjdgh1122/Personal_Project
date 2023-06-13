using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAIState : CommonAIState
{
    public override void OnEnterState()
    {
        _enemyMovement.IsRotate = true;
        _enemyMovement.StartImmediately();
        _enemyAnimationController.SetMove(MOVE_STATE.Move);
    }
    public override void OnExitState()
    {
        _enemyMovement.IsRotate = false;
        _enemyMovement.StopImmediately();
        _enemyAnimationController.SetMove(MOVE_STATE.Idle);
    }
    public override bool UpdateState()
    {
        return base.UpdateState();
    }
}
