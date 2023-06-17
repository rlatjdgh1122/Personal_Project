using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackEndDecision : AIDecision
{
    public override bool MakeDecision()
    {
        return _aIActionData.IsRangeAttacking == false;
    }
}
