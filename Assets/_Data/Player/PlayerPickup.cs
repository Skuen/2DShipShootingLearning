using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickUp(ItemPickupable itemPickupable)
    {
        Debug.Log("ItemPickup");

        ItemCode itemCode = itemPickupable.GetItemCode();
        if (this.playerController.CurrentShip.Inventory.AddItem(itemCode, 1))
        {
            itemPickupable.DespawnItem();
        }
    }
}
