using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = false; 
    [SerializeField] protected InventorySort inventorySort = InventorySort.ByName;
    [SerializeField] protected InventoryOrderBy inventoryOrderBy = InventoryOrderBy.ASC;

    protected override void Awake() {
        if(UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.Close();
        InvokeRepeating(nameof(this.ShowItems),1,1);
    }

    public virtual void Toggle(){
        this.isOpen = !this.isOpen;
        if(this.isOpen) this.Open();
        else this.Close();
    }
    public virtual void Open(){
        GameCtrl.Instance.PauseGame();
        transform.parent.gameObject.SetActive(true);
    }

    public virtual void Close(){
        GameCtrl.Instance.UnPauseGame();
        transform.parent.gameObject.SetActive(false);
    }

    protected virtual void ShowItems(){
        if(this.isOpen) return;     
        this.ReloadItems();
        this.SortItems();
    }

    public virtual void ReloadItems(){
        this.ClearItems();

        List<ItemInventory> items = PlayerCtrl.Instance.Inventory.Items;
        UIInventoryItemSpawner spawner = this.uIInventoryCtrl.UIInventoryItemSpawner;
        foreach (ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }
    }

    protected virtual void ClearItems(){
        this.uIInventoryCtrl.UIInventoryItemSpawner.ClearItems();
    }

    protected virtual void SortItems(){
        //Bubble Sort
        if(this.inventorySort == InventorySort.NoSort) return;
        int itemCount = this.uIInventoryCtrl.Content.childCount;
        Transform currentItem, nextItem;
        UIItemInventory currentUIItem, nextUIItem;
        bool isSorting = false;
        for(int i=0; i<itemCount-1;i++){
            currentItem = this.uIInventoryCtrl.Content.GetChild(i);
            nextItem = this.uIInventoryCtrl.Content.GetChild(i+1);

            currentUIItem = currentItem.GetComponent<UIItemInventory>();
            nextUIItem = nextItem.GetComponent<UIItemInventory>();

            bool isSwap = false;
            switch(inventorySort){
                case InventorySort.ByName:
                    ItemProfileSO currentProfileSO, nextProfileSO;
                    currentProfileSO = currentUIItem.ItemInventory.itemProfile;
                    nextProfileSO = nextUIItem.ItemInventory.itemProfile;

                    string currentItemName, nextItemName;
                    currentItemName = currentProfileSO.itemName;
                    nextItemName = nextProfileSO.itemName;
                    isSwap = (inventoryOrderBy == InventoryOrderBy.ASC) ? string.Compare(currentItemName, nextItemName) == 1 :
                                                            string.Compare(currentItemName, nextItemName) == -1;
                    break;
                
                case InventorySort.ByCount:
                    int currentItemCount = currentUIItem.ItemInventory.itemCount;
                    int nextItemCount = nextUIItem.ItemInventory.itemCount;
                    isSwap = (inventoryOrderBy == InventoryOrderBy.ASC) ? currentItemCount > nextItemCount :
                                                            currentItemCount < nextItemCount;
                    break;
            }
            if(isSwap){
                this.SwapItems(currentItem, nextItem);
                isSorting = true;
            }
        }  
        if(isSorting) this.SortItems();
    }

    protected virtual void SwapItems(Transform currentItem, Transform nextItem){
        int currentItemIndex = currentItem.GetSiblingIndex();
        int nextItemIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextItemIndex);
        nextItem.SetSiblingIndex(currentItemIndex);
    }
}
