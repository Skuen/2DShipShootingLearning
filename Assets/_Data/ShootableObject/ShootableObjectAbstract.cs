using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectAbstract: AlphaMonoBehavior
{
    [SerializeField] protected ShootableObjectController shootableObjectController;
    public ShootableObjectController ShootableObjectController => shootableObjectController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCopntroller();
    }
    protected virtual void LoadShootableObjectCopntroller()
    {
        if (this.shootableObjectController != null) return;
        this.shootableObjectController = transform.parent.GetComponent<ShootableObjectController>();
        Debug.Log(transform.name + ": ShootableObjectController", gameObject);

    }
}
