using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommonState : MonoBehaviour, IState
{
    public abstract void OnEnterState();
    public abstract void OnExitState();
    public abstract bool UpdateState();

    protected PlayerAnimator _playerAnimator;
    protected PlayerInput _playerInput;
    protected PlayerController _playerController;
   // protected AgentMovement _agentMovement;

    public virtual void SetUp(Transform agentRoot)
    {
        _playerAnimator = agentRoot.Find("Model").GetComponent<PlayerAnimator>();
        _playerInput = agentRoot.GetComponent<PlayerInput>();
        _playerController = agentRoot.GetComponent<PlayerController>();
        //_agentMovement = agentRoot.GetComponent<AgentMovement>();
    }
}   
