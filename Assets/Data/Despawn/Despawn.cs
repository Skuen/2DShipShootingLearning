using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : AlphaMonoBehavior
{
    //main
    protected virtual void FixedUpdate()
    {
        this.Despawning();
    }
    //abstract
    protected abstract bool IsDespawnable();

    //methods
    protected virtual void Despawning()
    {
        if (!this.IsDespawnable()) return;
        this.DespawnObject();

    }
    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
