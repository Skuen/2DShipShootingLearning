using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : AlphaMonoBehavior
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn { get => itemDespawn; }
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory { get => itemInventory; set => itemInventory = value; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
    }
    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": LoadItemDespawn", gameObject);
    }
    

}
