using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemAbtract : AlphaMonoBehavior
{
    [Header("Item Abstract")]
    [SerializeField] protected ItemController itemController;
    public ItemController ItemController { get => itemController; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.itemController != null) return;
        this.itemController = transform.parent.GetComponent<ItemController>();
        Debug.Log(transform.name + ": LoadModel", gameObject);

    }
}
