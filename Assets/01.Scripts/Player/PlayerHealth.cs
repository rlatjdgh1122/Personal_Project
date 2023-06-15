using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public UnityEvent OnHitTriggered = null;
    public UnityEvent OnDeadTriggered = null;

    public UnityEvent<int, int> OnHealthChanged = null;

    private int _maxHP;
    private int _currentHP;

    public bool IsDead { get; set; }
    public int MaxHP => _maxHP;
    public int CurrentHP => _currentHP;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }
    public void SetHp(int value)
    {
        _currentHP = _maxHP = value;
    }
    public void OnDamage(int damage)
    {
        if (IsDead) return;
        //_enemyHpBar.OnDamage(damage);
        OnHitTriggered?.Invoke();

        _currentHP -= damage;
        _currentHP = Mathf.Clamp(_currentHP, 0, _maxHP);

        _playerController.ChangeState(Core.StateType.OnHit);

        if (_currentHP <= 0)
        {
            OnDeadTriggered?.Invoke();
            IsDead = true;
        }


        OnHealthChanged?.Invoke(_currentHP, _maxHP); //그리고 전파
    }
}
