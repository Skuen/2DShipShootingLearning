using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickUp(ItemPickupable itemPickupable)
    {
        ItemInventory itemInventory = itemPickupable.ItemController.ItemInventory;
        if (this.playerController.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupable.DespawnItem();
        }
    }
}
