using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeaponable
{
    protected Animator animatorController;
    public abstract void Shooting();

    public abstract void StopShooting();

    public virtual void Reloading() { }

    protected virtual void Awake()
    {
        animatorController = GameObject.Find("Model").GetComponent<Animator>();
    }

}
