using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : AkiBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadItemDespawn();
        this.LoadItemInventory();
    }

    protected virtual void LoadItemDespawn(){
        if(this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + " LoadItemDespawn", gameObject);
    }

    public virtual void SetItemInventory(ItemInventory itemInventory){
        this.itemInventory = itemInventory;
    }

    protected virtual void LoadItemInventory(){
        if(this.itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        Debug.Log(itemCode+" "+itemProfile);
        this.itemInventory.itemProfile = itemProfile;
        this.itemInventory.itemCount = 1;
    }
}
