using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTextUI : TextUI
{
    protected override void Awake()
    {
        base.Awake();

        SignalHub.OnModifyBulletCount += Handler;
    }

    private void Handler(int curCount, int maxCount)
    {
        if (curCount == -1) curCount = 0;
        _text.text = $"<size=40> {curCount} </size> / {maxCount}<size=20>(MAX)</size>";
    }

    private void OnDestroy()
    {
        SignalHub.OnModifyBulletCount -= Handler;
    }
}
