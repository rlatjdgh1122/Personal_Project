using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackAIState : CommonAIState
{
    [SerializeField]
    private Transform pivot_Handle;
    [SerializeField]
    private GameObject bullet;

    private RockBullet b;

    protected bool _isActive = false;

    private float _lastAtkTime = 0;

    public float attackDelay = 7f;

    public override void OnEnterState()
    {
        _enemyAnimationController.SetMove(MOVE_STATE.Idle);

        _enemyMovement.IsMove = false;
        _enemyMovement.IsRotate = false;

        _enemyAnimationController.OnPreEndEventTrigger += WeaponThrow;
        _enemyAnimationController.OnPreEventTrigger += PickUpRock;
        _enemyAnimationController.OnEndEventTrigger += AttackAnimationEndHandle;

        _isActive = true;
    }
    private void PickUpRock()
    {
        GameObject g = Instantiate(bullet, pivot_Handle.position, Quaternion.identity, pivot_Handle);
        b = g.GetComponent<RockBullet>();

        b.SetDamage(_enemyController.EnemySoData.damage);
    }

    private void WeaponThrow()
    {
        b.Throw();
        b.gameObject.transform.SetParent(null);
    }
    private void AttackAnimationEndHandle()
    {
        _enemyAnimationController.SetShooting_Range(false);
        _lastAtkTime = Time.time;
        StartCoroutine(DelayCoroutine(() => _aiActionData.IsRangeAttacking = false, attackDelay));
    }

    private IEnumerator DelayCoroutine(Action Callback, float time)
    {
        yield return new WaitForSeconds(time);
        Callback?.Invoke();
    }
    public override void OnExitState()
    {
        _enemyAnimationController.OnPreEndEventTrigger -= WeaponThrow;
        _enemyAnimationController.OnPreEventTrigger -= PickUpRock;
        _enemyAnimationController.OnEndEventTrigger -= AttackAnimationEndHandle;

        _enemyMovement.IsMove = false;
        _enemyMovement.IsRotate = false;
        _isActive = false;
    }
    public void Reset_Rock()
    {
        if (b != null) Destroy(b);
    }
    public override bool UpdateState()
    {
        if (base.UpdateState())
        {
            return true;
        }
        if (_aiActionData.IsRangeAttacking == false && _isActive)  //¾×Æ¼ºê
        {
            _enemyMovement.IsRotate = true;
            if (_enemyMovement.IsLookTarget == true && _lastAtkTime + attackDelay < Time.time)
            {
                _aiActionData.IsRangeAttacking = true;
                _enemyAnimationController.SetShooting_Range(true);
            }
        }
        else
        {
            _enemyMovement.IsRotate = false;
            _enemyAnimationController.SetMove(MOVE_STATE.Idle);
        }
        return false;
    }
}
