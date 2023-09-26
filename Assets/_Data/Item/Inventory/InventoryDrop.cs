using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDrop : InventoryAbstract
{
    //[Header("Item Drop")]
    protected override void Start()
    {
        base.Start();
        //Invoke(nameof(Test), 5);
    }
    protected virtual void Test()
    {
        DropItemIndex(0);
    }
    protected virtual void DropItemIndex(int itemIndex)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];

        Vector3 position = transform.position;
        position.x += 1;

        ItemDropSpawner.Instance.Drop(itemInventory, position, transform.rotation);
        this.inventory.Items.Remove(itemInventory);
    }
}
