using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    public static ItemDropSpawner Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.Instance != null && Instance != this)
        {
            Debug.LogError("Only 1 Item Drop Spawner allow!!");
            Destroy(this);
            return;
        }
        ItemDropSpawner.Instance = this;
    }

    public virtual void Drop(List<DropRate> dropList, Vector3 position, Quaternion rotation)
    {
        //Debug.Log(dropList[0].itemSO.itemName);
        Transform itemDrop = this.Spawn(dropList[0].itemSO.itemCode.ToString(), position, rotation);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }
}
