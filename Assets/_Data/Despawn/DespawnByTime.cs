using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected float timer = 0;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTimer();
    }

    protected virtual void ResetTimer()
    {
        this.timer = 0;
    }

    protected override bool IsDespawnable()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer <= this.delay) return false;
        return true;
    }
}
