using System.Collections.Generic;
using System;
using UnityEngine;
using Core;
public class PlayerController : MonoBehaviour
{
    public IWeaponable currentWeapon;

    public PlayerDataSO playerData;
    private Dictionary<StateType, IState> _stateDictionary = null;
    private IState _currentState;
    private PlayerHealth _playerHealth;
    private PlayerMovement _playerMovement;
    public bool IsDead { get; set; }
    private void Awake()
    {
        _stateDictionary = new Dictionary<StateType, IState>();

        Transform stateTrm = transform.Find("States");

        foreach (StateType state in Enum.GetValues(typeof(StateType)))
        {
            IState stateScript = stateTrm.GetComponent($"{state}State") as IState;

            if (stateScript == null)
            {
                Debug.LogError($"There is no script : {state}");
                return;
            }
            stateScript.SetUp(transform);
            _stateDictionary.Add(state, stateScript);
        }
        _playerHealth = GetComponent<PlayerHealth>();
        _playerMovement = GetComponent<PlayerMovement>();
    }
    private void Start()
    {
        _playerHealth.SetHp(playerData.Hp);
        _playerMovement.SetSpeed(playerData.Speed);
        ChangeState(StateType.Normal);
    }

    public void ChangeState(StateType state)
    {
        _currentState?.OnExitState();
        _currentState = _stateDictionary[state];
        _currentState.OnEnterState();
    }
    private void Update()
    {
        Debug.Log(currentWeapon);
        if (IsDead) return;

        _currentState.UpdateState();
    }
}
