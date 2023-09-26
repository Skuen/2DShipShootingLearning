using System;
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
        this.LoadItemInventory();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetItem(); 
    }

    protected virtual void ResetItem()
    {
        this.itemInventory.itemCount = 1;
        this.itemInventory.upgradeLevel = 0;
    }

    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);

        this.itemInventory.itemProfile = itemProfile;
        this.ResetItem();
        Debug.Log(transform.name + ": LoadItemInventory", gameObject);

    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": LoadItemDespawn", gameObject);
    }
    

}
