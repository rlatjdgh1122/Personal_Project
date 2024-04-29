using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTextUI : TextUI
{
    protected override void Awake()
    {
        base.Awake();

        SignalHub.OnChagnedGun += Handler;
    }

    private void Handler(Gun weapon)
    {
        _text.text = weapon.name;
    }

    private void OnDestroy()
    {
        SignalHub.OnChagnedGun -= Handler;
    }
}
