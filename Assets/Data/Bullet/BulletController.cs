using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : AlphaMonoBehavior
{
    /// <summary>
    /// Only use for load Component and dependencies
    /// </summary>
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageSender();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }
}
