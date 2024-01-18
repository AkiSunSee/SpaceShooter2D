using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryDrop : InventoryAbstract
{
    //[Header("Item Drop")]

    [SerializeField] protected static ItemInventoryDrop instance;
    public static ItemInventoryDrop Instance => instance;
    
    protected override void Start(){
        base.Start();   
        //Invoke(nameof(this.Drop),10);
    }

    protected override void Awake()
    {
        base.Awake();
        if(ItemInventoryDrop.instance!= null) Debug.LogWarning("Only 1 ItemInventoryDrop can exist");
        ItemInventoryDrop.instance = this;
    }

    public virtual void Drop(){
        Vector3 dropPos = transform.parent.position;
        dropPos.x +=5;

        this.DropItemIndex(0,dropPos, transform.parent.rotation);
    }

    protected virtual void DropItemIndex(int itemIndex, Vector3 dropPos, Quaternion dropRot){
        if(itemIndex >= this.inventory.Items.Count) return;
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        
        ItemDropSpawner.Instance.DropFromInventory(itemInventory, dropPos, dropRot);
        this.inventory.Items.Remove(itemInventory);
    }
}
