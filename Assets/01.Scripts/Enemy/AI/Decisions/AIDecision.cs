using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    protected AIActionData _aIActionData;
    protected EnemyController _enemyController;
    protected EnemyMovement _enemyMovement;
    public bool IsReverse = false;

    public virtual void SetUp(Transform parentRoot)
    {
        _aIActionData = parentRoot.Find("AI").GetComponent<AIActionData>();
        _enemyController = parentRoot.GetComponent<EnemyController>();
        _enemyMovement = parentRoot.GetComponent<EnemyMovement>();
    }

    public abstract bool MakeDecision();
}
