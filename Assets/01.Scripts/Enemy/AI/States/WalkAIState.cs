using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAIState : CommonAIState
{
    public override void OnEnterState()
    {
        _enemyAnimationController.SetMove(MOVE_STATE.Walk);
        _enemyMovement.SetSpeed(Mathf.Clamp(_enemyController.EnemySoData.speed - 3, 2, _enemyController.EnemySoData.speed - 3));
    }

    public override void OnExitState()
    {

    }
    public override bool UpdateState()
    {
        return base.UpdateState();
    }
}
