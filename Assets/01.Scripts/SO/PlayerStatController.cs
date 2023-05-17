using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Core.Core;

public class PlayerStatController : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveSpeed -= 5;
            Debug.Log("wwer");
        }
    }
}
