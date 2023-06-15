using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IAIDamageable
{
    public UnityEvent OnHitTriggered = null;
    public UnityEvent OnDeadTriggered = null;

    private AIActionData _aiActionData;
    public Action<float, float> OnHealthChanged = null;

    public bool IsDead { get; set; }

    private int _maxHP;
    private int _currentHP;

    public int MaxHP => _maxHP;
    public int CurrentHP => _currentHP;

    private EnemyHpBar _enemyHpBar;
    private EnemyAnimationController _enemyAnimationController;
    private void Awake()
    {
        _aiActionData = transform.Find("AI").GetComponent<AIActionData>();
       _enemyHpBar = transform.root.transform.Find("Canvas").GetComponent<EnemyHpBar>();
        _enemyAnimationController = GetComponent<EnemyAnimationController>();
    }

    public void SetMaxHP(int value)
    {
        _currentHP = _maxHP = value;
        IsDead = false;
    }


    public void OnDamage(int damage, Vector3 point, Vector3 normal)
    {
        if (IsDead) return;

        _enemyHpBar.OnDamage(damage);
        OnHitTriggered?.Invoke();

        _aiActionData.HitPoint = point;
        _aiActionData.HitNormal = normal;

        _currentHP -= damage;
        _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);
        if (_currentHP <= 0)
        {
            IsDead = true;
            OnDeadTriggered?.Invoke();
            _enemyAnimationController.Die();
        }
        OnHealthChanged?.Invoke(_currentHP, _maxHP); //그리고 전파
    }
}
