using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAnimation : MonoBehaviour
{
    protected Animator anim;
   protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }
}
