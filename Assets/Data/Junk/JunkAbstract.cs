using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : AlphaMonoBehavior
{
    [SerializeField] protected JunkController junkController;
    public JunkController JunkController { get => junkController; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.junkController != null) return;
        this.junkController = transform.parent.GetComponent<JunkController>();
        Debug.Log(transform.name + ": LoadModel", gameObject);

    }
}
