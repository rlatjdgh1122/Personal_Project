using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAIState : CommonAIState
{
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
        _enemyAnimationController.SetShooting(false);
        _lastAtkTime = Time.time; //이제부터 1초 기다렸다가 다시 레이저 발사
        //StartCoroutine(DelayCoroutine(() => _aiActionData.IsAttacking = false, _enemyController.EnemySoData.weaponData.motionDelay));
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
            Vector3 currentFrontVector = transform.forward;
            float angle = Vector3.Angle(currentFrontVector, _targetVector);

            if (angle >= 10f)
            {
                _enemyMovement.IsRotate = true;
            }
            //if (_lastAtkTime + _enemyController.EnemySoData.weaponData.attackCoolTime < Time.time) //쿨타임도 찼고 각도도 10도로 들어왔다면
            {   
                _enemyMovement.IsRotate = false;
                _aiActionData.IsAttacking = true;
                _enemyAnimationController.SetShooting(true);
            }
        }

        return false;
    }
}
