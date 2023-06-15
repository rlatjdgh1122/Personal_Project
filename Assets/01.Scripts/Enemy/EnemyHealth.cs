using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public UnityEvent OnHitTriggered = null;
    public UnityEvent OnDeadTriggered = null;

    private AIActionData _aiActionData;
    public Action<float, float> OnHealthChanged = null;

    public bool IsDead { get; set; }

    private float _maxHP;
    private float _currentHP;

    public float MaxHP => _maxHP;
    public float CurrentHP => _currentHP;

    private EnemyHpBar _enemyHpBar;
    private void Awake()
    {
        _aiActionData = transform.Find("AI").GetComponent<AIActionData>();
       _enemyHpBar = transform.root.transform.Find("Canvas").GetComponent<EnemyHpBar>();
    }

    public void SetMaxHP(float value)
    {
        _currentHP = _maxHP = value;
        IsDead = false;
    }


    public void OnDamage(int damage, Vector3 point, Vector3 normal)
    {
        if (IsDead) return;

        _enemyHpBar.OnDamage(damage);

        _aiActionData.HitPoint = point;
        _aiActionData.HitNormal = normal;

        _currentHP -= damage;
        _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);
        if (_currentHP <= 0)
        {
            IsDead = true;
            OnDeadTriggered?.Invoke();
        }

        OnHitTriggered?.Invoke();

        OnHealthChanged?.Invoke(_currentHP, _maxHP); //그리고 전파
    }
}
