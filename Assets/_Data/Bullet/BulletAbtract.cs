using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbtract : AlphaMonoBehavior
{
    [Header("Bullet Abtract")]
    [SerializeField] protected BulletController bulletController;
    public BulletController BulletController { get => bulletController; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.bulletController != null) return;
        this.bulletController = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }
}
