using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectController : AlphaMonoBehavior
{
    [SerializeField] protected Transform model;
    public Transform Model => model;
    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;
    [SerializeField] protected ShootableObjectSO shootableObjectSO;
    public ShootableObjectSO ShootableObjectSO => shootableObjectSO;
    [SerializeField] protected ObjectShooting objectShooting;
    public ObjectShooting ObjectShooting => objectShooting;
    [SerializeField] protected ObjectLookAtTarget objectLookAtTarget;
    public ObjectLookAtTarget ObjectLookAtTarget => objectLookAtTarget;
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
        this.LoadObjectShooting();
        this.LoadObjectLookAtTarget();
        this.LoadSpawner();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);

    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }
    protected virtual void LoadSO()
    {
        if (this.shootableObjectSO != null) return;
        string resourcesPath = "ShootableObject/"+this.GetObjectTypeString()+"/" + transform.name;
        this.shootableObjectSO = Resources.Load<ShootableObjectSO>(resourcesPath);
        Debug.Log(transform.name + ": ShootableObject", gameObject);
    }
    protected virtual void LoadObjectShooting()
    {
        if (this.objectShooting != null) return;
        this.objectShooting = GetComponentInChildren<ObjectShooting>();
        Debug.Log(transform.name + ": ObjectShooting", gameObject);
    }
    protected virtual void LoadObjectLookAtTarget()
    {
        if (this.objectLookAtTarget != null) return;
        this.objectLookAtTarget = GetComponentInChildren<ObjectLookAtTarget>();
        Debug.Log(transform.name + ": ObjectLookAtTarget", gameObject);
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent?.parent?.GetComponent<Spawner>();
        Debug.Log(transform.name + ": Spawner", gameObject);
    }
    protected abstract string GetObjectTypeString();
    
}
