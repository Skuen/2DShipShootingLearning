using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : AlphaMonoBehavior
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items => items;
    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.CopperSword, 1);
        this.AddItem(ItemCode.GoldOre, 10);
        this.AddItem(ItemCode.IronOre, 10);
    }
    public virtual bool AddItem(ItemInventory itemInventory)
    {
        ItemProfileSO itemProfile = itemInventory.itemProfile;
        int addCount = itemInventory.itemCount;

        if (itemProfile.itemType == ItemType.Equipment) return this.AddEquiment(itemInventory);

        return this.AddItem(itemProfile.itemCode,addCount);
    }
    public virtual bool AddEquiment(ItemInventory itemInventory)
    {
        if (this.IsInventoryFull()) return false;
        ItemInventory item = itemInventory.Clone();
        this.items.Add(item);
        return true;
    }


    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {

        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;
        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode);
            if (itemExist == null)
            {
                if (this.IsInventoryFull()) return false;

                itemExist = this.CreateEmptyItem(itemProfile);
                this.items.Add(itemExist);
            }

            newCount = itemExist.itemCount + addRemain;

            itemMaxStack = this.GetMaxStack(itemExist);
            if (newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }

            itemExist.itemCount = newCount;
            if (addRemain < 1) break;
        }

        return true;
    }

    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        for (int i = this.items.Count-1; i >=0; i--)
        {
            int deduct;
            if (deductCount <= 0) break;
            if (items[i].itemProfile.itemCode != itemCode) continue;

            if (deductCount > items[i].itemCount)
            {
                deduct = items[i].itemCount;
                deductCount -= items[i].itemCount;
            }
            else
            {
                deduct = deductCount;
                deductCount = 0;
            }

            items[i].itemCount -= deduct;
        }
        this.ClearEmptySlot();
    }

    protected virtual void ClearEmptySlot()
    {
        for (int i = 0; i < this.items.Count; i++)
        {
            if (this.items[i].itemCount == 0) this.items.RemoveAt(i);
        }
    }

    public virtual bool ItemCheck(ItemCode itemCode, int numberCheck)
    {
        int totalCount = this.ItemTotalCount(itemCode);
        return totalCount >= numberCheck;
    }

    public virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach (ItemInventory item in this.items)
        {
            if (item.itemProfile.itemCode != itemCode) continue;
            totalCount += item.itemCount;
        }
        return totalCount;
    }

    protected virtual bool IsInventoryFull()
    {
        if (this.items.Count >= this.maxSlot) return true;
        return false;
    }
    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;

        return itemInventory.maxStack;
    }

    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }
    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemCode != itemInventory.itemProfile.itemCode) continue;
            if (this.IsFullStack(itemInventory)) continue;
            return itemInventory;
        }

        return null;
    }
    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;

        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }

    protected virtual ItemInventory CreateEmptyItem(ItemProfileSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = itemProfile,
            maxStack = itemProfile.defaultMaxStack
        };

        return itemInventory;
    }
}
