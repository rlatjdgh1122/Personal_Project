using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAIState : CommonAIState
{
    public override void OnEnterState()
    {
        _enemyAnimationController.SetMove(MOVE_STATE.Run);
        _enemyMovement.SetSpeed(_enemyController.EnemySoData.speed);
    }
    public override void OnExitState()
    {

    }
    public override bool UpdateState()
    {
        return base.UpdateState();
    }
}
