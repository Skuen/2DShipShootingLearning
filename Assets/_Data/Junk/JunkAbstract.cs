using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : AlphaMonoBehavior
{
    [Header("Junk Abstract")]
    [SerializeField] protected JunkController junkController;
    public JunkController JunkController { get => junkController; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.junkController != null) return;
        this.junkController = transform.parent.GetComponent<JunkController>();
        Debug.Log(transform.name + ": LoadModel", gameObject);

    }
}
