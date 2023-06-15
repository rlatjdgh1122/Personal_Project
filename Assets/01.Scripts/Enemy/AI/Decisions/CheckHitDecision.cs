
using UnityEngine;

public class CheckHitDecision : AIDecision
{
    public override bool MakeDecision()
    {
        Debug.Log(_aIActionData.IsHit);
        return _aIActionData.IsHit;
    }
}
