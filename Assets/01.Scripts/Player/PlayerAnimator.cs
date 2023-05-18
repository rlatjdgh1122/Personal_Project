using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    public Animator Animator => _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
