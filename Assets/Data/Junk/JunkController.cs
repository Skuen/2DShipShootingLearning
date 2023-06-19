using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkController : AlphaMonoBehavior
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);

    }
}
