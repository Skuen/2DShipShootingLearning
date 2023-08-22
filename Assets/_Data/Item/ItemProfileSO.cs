using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObjects/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.None;
    public ItemType itemType = ItemType.None;
    public string itemName = "no-name";
    public int defaultMaxStack = 7;
}
