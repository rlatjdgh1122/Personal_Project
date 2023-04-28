using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public void Rotation(Vector3 target)
    {
        if(target == Vector3.zero) return;
        target.y = 0;
        transform.rotation = Quaternion.LookRotation(target);
    }
}
