using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem; 
    public string itemName = "Item";

    public enum ItemCode
    {
        NoItem =0,
        IronOre =1,
        GoldOre =2
    }
}
