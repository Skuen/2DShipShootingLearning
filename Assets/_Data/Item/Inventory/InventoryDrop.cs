using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDrop : InventoryAbstract
{
    //[Header("Item Drop")]
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(Test), 5);
    }
    protected virtual void Test()
    {
        Vector3 position = transform.position;
        position.x += 1;
        DropItemIndex(0, position,transform.rotation);
    }
    protected virtual void DropItemIndex(int itemIndex, Vector3 position, Quaternion rotation)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];

        ItemDropSpawner.Instance.Drop(itemInventory, position, rotation);
        this.inventory.Items.Remove(itemInventory);
    }
}
