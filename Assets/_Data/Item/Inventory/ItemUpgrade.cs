using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{
    [Header("Item Upgrade")]
    [SerializeField] protected int maxLevel = 9;

    protected override void Start(){
        base.Start();
        Invoke(nameof(this.Test),1);
        Invoke(nameof(this.Test),2);
        Invoke(nameof(this.Test),3);
    }

    protected virtual void Test(){
        this.UpgradeItem(0);
    }

    public virtual bool UpgradeItem(int itemIndex){
        //Debug.Log("Upgrading...");
        if(this.inventory == null) return false;

        if(itemIndex >= this.inventory.Items.Count) return false;

        ItemInventory itemInventory =  this.inventory.Items[itemIndex];
        if(itemInventory.itemCount < 1) return false;

        List<ItemRecipe> upgradeLevels = itemInventory.itemProfile.upgradeLevels;
        if(!this.ItemUpgradeable(upgradeLevels)) return false;
        if(!this.HaveEnoughIngredients(upgradeLevels, itemInventory.upgradeLevel)) return false;

        this.DeductIngredients(upgradeLevels, itemInventory.upgradeLevel);
        itemInventory.upgradeLevel++;
        //Debug.Log("Upgrade item: "+itemInventory.itemProfile.itemCode+" to level "+itemInventory.upgradeLevel + " success");

        return true;
    }

    protected virtual bool ItemUpgradeable(List<ItemRecipe> upgradeLevels){
        if(upgradeLevels.Count == 0) return false;
        return true;
    }

    protected virtual bool HaveEnoughIngredients(List<ItemRecipe> upgradeLevels, int currentLevel){
        if (currentLevel >= upgradeLevels.Count) return false;

        List<ItemRecipeIngredients> itemsRequire = upgradeLevels[currentLevel].ingredients;
        if(itemsRequire == null) return false;
        ItemCode itemCode;
        int itemCount;
        foreach (ItemRecipeIngredients item in itemsRequire){   
            itemCode = item.itemProfile.itemCode;
            itemCount = item.itemCount;
            if(!this.inventory.HaveEnoughItem(itemCode, itemCount)) return false;
        }

        return true;
    }

    protected virtual void DeductIngredients(List<ItemRecipe> upgradeLevels, int currentLevel){
        List<ItemRecipeIngredients> itemsRequire = upgradeLevels[currentLevel].ingredients;
        if(itemsRequire == null) return;
        ItemCode itemCode;
        int itemCount;
        foreach (ItemRecipeIngredients item in itemsRequire)
        {
            itemCode = item.itemProfile.itemCode;
            itemCount = item.itemCount;
            if(!this.inventory.DeductItem(itemCode, itemCount)) return;
        }

    }
}
