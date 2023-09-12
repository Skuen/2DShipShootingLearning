using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{
    [Header("Item Upgrade")]
    [SerializeField] protected int maxLevel = 9;
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 1);
        Invoke(nameof(this.Test), 2);
        Invoke(nameof(this.Test), 3);
    }

    protected virtual void Test()
    {
        this.UpgradeItem(0);
    }

    public virtual bool UpgradeItem(int itemIndex)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];

        if (itemIndex >= this.inventory.Items.Count) return false;
        if (itemInventory.itemCount < 1) return false;

        List<ItemRecipe> upgradeLevels = itemInventory.itemProfile.upgradeLevels;
        if (!this.ItemUpgradeable(upgradeLevels)) return false;
        if (!this.HaveEnoughIngredients(upgradeLevels, itemInventory.upgradeLevel)) return false;

        this.DeductIngredient(upgradeLevels, itemInventory.upgradeLevel);
        itemInventory.upgradeLevel++;

        return true;
    }

    protected virtual void DeductIngredient(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        foreach(ItemRecipeIngredient ingredient in upgradeLevels[currentLevel].ingredients)
        {
            this.inventory.DeductItem(ingredient.itemProfile.itemCode, ingredient.itemCount);
        }
    }

    protected virtual bool HaveEnoughIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        if(currentLevel >= upgradeLevels.Count)
        {
            Debug.LogError("Item can't upgrade anymore, current: " + currentLevel);
            return false;
        }

        foreach(ItemRecipeIngredient ingredient in upgradeLevels[currentLevel].ingredients)
        {
            if (!this.inventory.ItemCheck(ingredient.itemProfile.itemCode, ingredient.itemCount)) return false;
        }
        return true;
    }

    protected virtual bool ItemUpgradeable(List<ItemRecipe> upgradeLevels)
    {
        if (upgradeLevels.Count == 0) return false;
        return true;
    }
}
