using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : InventoryAbstract
{
    //[Header("Item Drop")]
    protected override void Start()
    {
        base.Start();
    }

    protected virtual void DropItemIndex(int itemIndex)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];

        Vector3 position = transform.position;
        position.x += 1;
        //Quaternion rotation = transform.rotation;

        ItemDropSpawner.Instance.Drop(itemInventory, position, transform.rotation);
    }
}
