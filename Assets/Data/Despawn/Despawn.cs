using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : AlphaMonoBehavior
{
    /// <summary>
    /// This Despawn script destroy object completely
    /// But right now our game using Object Pool Pattern so we don't use this scrpit rn
    /// We are using The despawn in Spawner(It's mean we just disable it to reuse later not really despawn)
    /// So check out The Spawner Class in Assets/Data/Spawner
    /// </summary>
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
    public virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
