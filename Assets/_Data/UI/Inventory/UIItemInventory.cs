using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : AkiBehaviour
{
    [Header("UI Item Inventory")]

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Text itemCount;
    public Text ItemCount => itemCount;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemCount();
    }

    protected virtual void LoadItemName(){
        if(this.itemName != null) return;
        this.itemName = transform.Find("ItemName").GetComponent<Text>();
        Debug.LogWarning(transform.name+": LoadItemName",gameObject);
    }

    protected virtual void LoadItemCount(){
        if(this.itemCount != null) return;
        this.itemCount = transform.Find("ItemCount").GetComponent<Text>();
        Debug.LogWarning(transform.name+": LoadItemCount",gameObject);
    }

    public virtual void ShowItem(ItemInventory item){
        this.itemInventory = item;
        this.itemName.text = item.itemProfile.itemName;
        this.itemCount.text = item.itemCount.ToString();
    }
}
