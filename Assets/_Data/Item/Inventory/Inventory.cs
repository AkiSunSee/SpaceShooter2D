using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : AkiBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected int curSlot = 0;
    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items => items;

    protected override void Start() {
        base.Start();
        this.AddItem(ItemCode.GoldenSword,1);
        this.AddItem(ItemCode.IronOre,15);
        this.AddItem(ItemCode.GoldOre,60);
    }
    
    public virtual bool IsInventoryFull(){
        return this.curSlot >= this.maxSlot;
    }

    public virtual bool AddItem(ItemInventory itemInventory){
        int addCount = itemInventory.itemCount;
        ItemProfileSO itemProfile = itemInventory.itemProfile;
        
        ItemCode itemCode = itemProfile.itemCode;
        ItemType itemType = itemProfile.itemType;
        //Debug.Log(itemCode+ " "+itemType);
        if(itemType == ItemType.Resources) return this.AddItem(itemCode, addCount);
        if(itemType == ItemType.Equipment) return this.AddEquipment(itemInventory);

        return true;
    }

    public virtual bool AddEquipment(ItemInventory itemInventory){
        if(this.IsInventoryFull()) return false;
        this.items.Add(itemInventory);
        return true;
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount){
        if(this.IsInventoryFull()){
            //Debug.Log("Inventory is full!");
            return false;}
        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;

        ItemInventory itemExist;
        for(int i=0; i< this.maxSlot; i++){
            itemExist = this.GetItemNotFullStack(itemCode);
            if(itemExist == null){
                itemExist = this.CreateEmptyItem(itemProfile);
                this.items.Add(itemExist);
            }

            newCount = itemExist.itemCount + addRemain;

            itemMaxStack = this.GetMaxStack(itemExist);
            if(newCount > itemMaxStack){
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemMaxStack;
                addRemain -= addMore;
                this.curSlot += addMore;
            }else{
                this.curSlot += addRemain;
                addRemain -= newCount;
            }
            itemExist.itemCount = newCount;
            if(addRemain <1) break;
        }
        
        return true;
    }

    public virtual int GetMaxStack(ItemInventory itemInventory){
        if(itemInventory == null) return 0;
        return itemInventory.maxStack;
    }

    public virtual bool IsFullStack(ItemInventory itemInventory){
        if(itemInventory == null) return true;
        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }

    public virtual ItemProfileSO GetItemProfile(ItemCode itemCode){
        return ItemProfileSO.FindByItemCode(itemCode);
    }

    public virtual ItemInventory GetItemNotFullStack(ItemCode itemCode){
        foreach (ItemInventory item in this.items)
        {
            if ((item.itemProfile.itemCode == itemCode) && !this.IsFullStack(item)) return item;
        }
        return null;
    }

    public virtual ItemInventory CreateEmptyItem(ItemProfileSO itemPSO){
        ItemInventory itemInventory = new ItemInventory{
            itemProfile =  itemPSO,
            itemCount = 0,
            maxStack = itemPSO.defaultMaxStack
        };
        return itemInventory;
    }
    
    public virtual bool HaveEnoughItem(ItemCode itemCode, int needCount){
        int itemCount = 0;
        foreach (ItemInventory item in this.items)
        {
            if(itemCode == item.itemProfile.itemCode) itemCount+=item.itemCount;
        }
        return itemCount >= needCount;
    }

    public virtual bool DeductItem(ItemCode itemCode, int deductCount){
        if(deductCount <= 0) return false;
        int deductRemain = deductCount;
        //Debug.Log(itemCode.ToString()+ " - " + deductCount);
        ItemInventory item = this.GetItemByCode(itemCode);
        if(item == null) return false;
        if(item.itemCount <= deductRemain){
            deductRemain -= item.itemCount;
            this.curSlot -= item.itemCount;
            this.items.Remove(item);
            DeductItem(itemCode, deductRemain);
        }else{
            int newCount = item.itemCount - deductRemain; // 7-6
            item.itemCount = newCount; //=1
            this.curSlot -= deductRemain;
            return true;
        }
        return true;
    }

    protected virtual ItemInventory GetItemByCode(ItemCode itemCode){
        ItemInventory itemInventory = this.items.Find((item)=> item.itemProfile.itemCode == itemCode);
        return itemInventory;
    }
    /* public virtual bool AddItem(ItemCode itemCode, int addCount){
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        
        int newCount = itemInventory.itemCount + addCount;
        if (newCount > itemInventory.maxStack) return false;

        itemInventory.itemCount = newCount;
        return true;
    }

    public virtual bool DeductItem(ItemCode itemCode, int deductCount){
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount - deductCount;
        if (newCount < 0) return false;

        itemInventory.itemCount = newCount;
        return true;
    }

    protected virtual ItemInventory GetItemByCode(ItemCode itemCode){
        ItemInventory itemInventory = this.items.Find((item)=> item.itemProfile.itemCode == itemCode);
        if(itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
        return itemInventory;
    }

    protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode){
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if(profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profile,
                maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }
        return null;
    } */
}
