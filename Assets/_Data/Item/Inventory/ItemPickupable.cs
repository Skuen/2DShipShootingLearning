using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : ItemAbtract
{
    [Header("Item Pickupable")]
    [SerializeField] protected SphereCollider _collider;
    protected virtual void OnMouseDown()
    {
        Debug.Log(transform.parent.name);
        PlayerController.Instance.PlayerPickup.ItemPickUp(this);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();

    }
    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.2f;
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    public virtual ItemCode GetItemCode()
    {
        ItemCode itemCode;
        if(System.Enum.TryParse<ItemCode>(transform.parent.name, out itemCode)) return itemCode;
        return ItemCode.None;
        //return (ItemCode)System.Enum.Parse(typeof(ItemCode), transform.parent.name);
    }
    public virtual void DespawnItem()
    {
        this.ItemController.ItemDespawn.DespawnObject();
    }
    
}
