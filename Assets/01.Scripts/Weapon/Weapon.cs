using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeaponable
{
   public abstract void Shooting();
   public virtual void StopShooting() { }
}
