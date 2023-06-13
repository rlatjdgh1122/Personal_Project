using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAIState : CommonAIState
{
    public float motionDelay = 1;
    protected Vector3 _targetVector;
    protected bool _isActive = false;

    private float _lastAtkTime;
    private void Start()
    {
        _targetVector = GameManager.Instance.playerPos.position;
    }
    public override void OnEnterState()
    {
        _enemyMovement.IsActive = false;

        _enemyAnimationController.OnEndEventTrigger += AttackAnimationEndHandle;
        _enemyAnimationController.OnPreEventTrigger += AttackAnimationPreHandle;
        _isActive = true;
    }

    private void AttackAnimationPreHandle()
    {

    }

    private void AttackAnimationEndHandle()
    {
        Debug.Log("애니메이션 끝");
        _enemyAnimationController.SetShooting(false);
        _lastAtkTime = Time.time; //이제부터 1초 기다렸다가 다시 레이저 발사
        StartCoroutine(DelayCoroutine(() => _aiActionData.IsAttacking = false, _enemyController.EnemySoData.attackDelay));
    }

    private IEnumerator DelayCoroutine(Action Callback, float time)
    {
        yield return new WaitForSeconds(time);
        Callback?.Invoke();
    }
    public override void OnExitState()
    {
        _enemyAnimationController.OnEndEventTrigger -= AttackAnimationEndHandle;
        _enemyAnimationController.OnPreEventTrigger -= AttackAnimationPreHandle;

        _enemyMovement.IsActive = true;

        _aiActionData.IsAttacking = false;
        _isActive = false;
    }

    public override bool UpdateState()
    {
        if (base.UpdateState())
        {
            return true;
        }
        if (_aiActionData.IsAttacking == false && _isActive)  //액티브
        {
            if (_lastAtkTime + _enemyController.EnemySoData.attackDelay < Time.time) //쿨타임도 찼고 각도도 10도로 들어왔다면
            {
                _aiActionData.IsAttacking = true;
                _enemyAnimationController.SetShooting(true);
            }
        }

        return false;
    }
}
