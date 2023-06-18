using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyHealth : MonoBehaviour, IDamageable
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
    private EnemyController enemyController;
    private void Awake()
    {
        _aiActionData = transform.Find("AI").GetComponent<AIActionData>();
        _enemyHpBar = transform.root.transform.Find("Canvas").GetComponent<EnemyHpBar>();
        _enemyAnimationController = GetComponent<EnemyAnimationController>();
        enemyController = GetComponent<EnemyController>();
    }

    public void SetMaxHP(int value)
    {
        _currentHP = _maxHP = value;
        IsDead = false;
    }
    public void OnDamage(int damage)
    {
        if (IsDead) return;
        int randomDamage = Mathf.Clamp(Random.Range(damage - 5, damage + 5), damage, damage + 5);

        _enemyHpBar.OnDamage(damage);
        OnHitTriggered?.Invoke();

        _currentHP -= randomDamage;
        _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);
        if (_currentHP <= 0)
        {
            IsDead = true;
            OnDeadTriggered?.Invoke();
            _enemyAnimationController.Die();

            WaveManager.instance.currentEnemyCount--;
            LevelController.Instance.SetLevelValue(enemyController.EnemySoData.getExperience);
            Destroy(this.gameObject, 3f);
        }
        OnHealthChanged?.Invoke(_currentHP, _maxHP); //그리고 전파
    }
}
