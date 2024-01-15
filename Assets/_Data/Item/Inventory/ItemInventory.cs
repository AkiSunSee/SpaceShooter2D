using System;

[Serializable]

public class ItemInventory{
    public string itemID;
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public string Item { get; internal set; }

    public virtual ItemInventory Clone(ItemInventory itemInventory){
        ItemInventory cloneItemInventory = new ItemInventory();
        cloneItemInventory.itemID = itemInventory.itemID;
        cloneItemInventory.itemProfile = itemInventory.itemProfile;
        cloneItemInventory.itemCount = itemInventory.itemCount;
        cloneItemInventory.maxStack = itemInventory.itemProfile.defaultMaxStack;
        cloneItemInventory.upgradeLevel = itemInventory.upgradeLevel;

        return cloneItemInventory;
    }

    public virtual ItemInventory Clone(){
        ItemInventory item = new ItemInventory{
            itemID = ItemInventory.RandomID(),
            itemProfile = this.itemProfile,
            itemCount = this.itemCount,
            upgradeLevel = this.upgradeLevel
        };
        return item;
    }

    // public ItemInventory(){
    //     this.itemID = ItemInventory.RandomID();
    // }

    public virtual string GetItemID(){
        return this.itemID;
    }

    public virtual void SetItemID(string itemID){
        this.itemID = itemID;
    }

    public static string RandomID(){
        return RandomStringGenerator.Generate(10);
    }
}