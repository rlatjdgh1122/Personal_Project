using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIActionData : MonoBehaviour
{
    private Vector3 hitPoint;
    public Vector3 HitPoint
    {
        get { return hitPoint; }
        set { hitPoint = value; }
    }
    private Vector3 hitNomal;
    public Vector3 HitNomal
    {
        get { return hitNomal; }
        set { hitNomal = value; }
    }

    public bool IsAttack;

}
