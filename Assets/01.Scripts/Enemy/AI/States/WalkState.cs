using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : CommonAIState
{
    public override void OnEnterState()
    {

        _enemyMovement.SetSpeed(Mathf.Clamp(_enemyController.EnemySoData.speed - 5,2, _enemyController.EnemySoData.speed - 5));
    }

    public override void OnExitState()
    {

    }
    public override bool UpdateState()
    {
        return base.UpdateState();
    }
}
