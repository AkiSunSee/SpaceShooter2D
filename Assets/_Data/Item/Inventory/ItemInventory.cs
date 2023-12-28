using System;

[Serializable]

public class ItemInventory{
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public virtual ItemInventory Clone(ItemInventory itemInventory){
        ItemInventory cloneItemInventory = new ItemInventory();
        cloneItemInventory.itemProfile = itemInventory.itemProfile;
        cloneItemInventory.itemCount = itemInventory.itemCount;
        cloneItemInventory.maxStack = itemInventory.itemProfile.defaultMaxStack;
        cloneItemInventory.upgradeLevel = itemInventory.upgradeLevel;

        return cloneItemInventory;
    }
}