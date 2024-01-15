using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryItemSpawner : Spawner
{
    private static UIInventoryItemSpawner instance;
    public static UIInventoryItemSpawner Instance { get => instance; }

    [Header("UI Inventory Item Spawner")]
    [SerializeField] protected UIInventoryCtrl uIInventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => uIInventoryCtrl;

    public static string normalItem = "UIItemInventory";

    protected override void Awake() {
        base.Awake();
        if(UIInventoryItemSpawner.instance != null) Debug.LogError("Only 1 UIInventoryItemSpawner allow to exist");
        UIInventoryItemSpawner.instance = this;
    }

    protected virtual void LoadUIInventoryCtrl(){
        if(this.uIInventoryCtrl != null) return;
        this.uIInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.LogWarning(transform.name+": LoadUIInvetoryCtrl",gameObject);
    }

    protected override void LoadHolder()
    {
        this.LoadUIInventoryCtrl();
        
        if(this.holder != null) return;
        this.holder = this.uIInventoryCtrl.Content;
        Debug.LogWarning(transform.name + ": LoadHolder",gameObject);
    }

    public virtual void ClearItems(){
        foreach (Transform item in this.holder)
        {
            this.Despawn(item);
        }
    }

    public virtual void SpawnItem(ItemInventory item){
        Transform newUIItemInventory = base.Spawn(UIInventoryItemSpawner.normalItem,Vector3.zero,Quaternion.identity);
        newUIItemInventory.transform.localScale = new Vector3(1,1,1);
        UIItemInventory itemInventory = newUIItemInventory.GetComponent<UIItemInventory>();
        itemInventory.ShowItem(item);
        newUIItemInventory.gameObject.SetActive(true);
    }
}
