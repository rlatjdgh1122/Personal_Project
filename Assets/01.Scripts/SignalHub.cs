using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ChangeGun(Gun weapon);
public delegate void ModifyBulletCount(int curCount, int maxCount);
public static class SignalHub
{
    public static ChangeGun OnChagnedGun;
    public static ModifyBulletCount OnModifyBulletCount;
}
