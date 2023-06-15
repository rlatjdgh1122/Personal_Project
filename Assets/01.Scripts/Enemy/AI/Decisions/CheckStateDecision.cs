using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStateDecision : AIDecision
{

    [SerializeField]
    private CommonAIState _baseState;

    public override bool MakeDecision()
    {
        Debug.Log(_enemyController._currentState == _baseState);
        return _enemyController._currentState == _baseState;
    }
}
