using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weaponable : MonoBehaviour
{
   public abstract void Shooting();
   public virtual void StopShooting() { }
}
