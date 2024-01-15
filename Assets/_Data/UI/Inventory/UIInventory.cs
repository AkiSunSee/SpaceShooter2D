using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = false; 

    protected override void Awake() {
        if(UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }

    protected virtual void FixedUpdate(){
        //this.ShowItem();
    }
    protected override void Start()
    {
        base.Start();
        //this.Close();
        InvokeRepeating(nameof(this.ShowItem),1,1);
    }

    public virtual void Toggle(){
        this.isOpen = !this.isOpen;
        if(this.isOpen) this.Open();
        else this.Close();
    }
    public virtual void Open(){
        transform.parent.gameObject.SetActive(true);
    }

    public virtual void Close(){
        transform.parent.gameObject.SetActive(false);
    }

    protected virtual void ShowItem(){
        if(this.isOpen) return;     
        this.ClearItems();

        List<ItemInventory> items = PlayerCtrl.Instance.CurrentShip.Inventory.Items;
        UIInventoryItemSpawner spawner = this.uIInventoryCtrl.UIInventoryItemSpawner;
        foreach (ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }
    }

    protected virtual void ClearItems(){
        this.uIInventoryCtrl.UIInventoryItemSpawner.ClearItems();
    }

}
