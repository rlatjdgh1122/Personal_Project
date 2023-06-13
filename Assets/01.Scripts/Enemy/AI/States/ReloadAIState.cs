using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadAIState : CommonAIState
{
    public CommonAIState attackState;
    private float time = 0;
    public override void OnEnterState()
    {
        _enemyAnimationController.SetReloading(true);
        _enemyMovement.IsRotate = false;

    }
    public override void OnExitState()
    {
        _enemyMovement.IsRotate = true;
        _enemyAnimationController.SetReloading(false);
        time = 0;

    }

    public override bool UpdateState()
    {
        time += Time.deltaTime;
        if (time <= _enemyController.EnemySoData.weaponData.reloadTime) return false;
        else
        {
            _enemyController.ChangeState(attackState);
            return true;
        }

    }
}
