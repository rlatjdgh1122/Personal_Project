using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDistanceDecision : AIDecision
{
    [SerializeField]
    private float _distance = 5f;

    public override bool MakeDecision()
    {
        if (_enemyController._targetTrm == null) return true;

        float distance = Vector3.Distance(_enemyController._targetTrm.position, transform.position);

        if (distance < _distance)  //�þ� ������ ���Դٸ�
        {
            _aIActionData.LastSpotPoint = _enemyController._targetTrm.position;
            _aIActionData.TargetSpotted = true;
        }
        else
        {
            _aIActionData.TargetSpotted = false;
        }
        return _aIActionData.TargetSpotted;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (UnityEditor.Selection.activeObject == gameObject)
        {
            Color old = Gizmos.color;
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _distance);
            Gizmos.color = old;
        }
    }
#endif
}
