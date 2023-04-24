using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
   public void Rotation(Vector3 target)
    {
        transform.LookAt(target);
    }
}
