using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryDrop : InventoryAbstract
{
    //[Header("Item Drop")]
    
    protected override void Start(){
        base.Start();   
        Invoke(nameof(this.Test),10);
    }

    protected virtual void Test(){
        Vector3 dropPos = transform.parent.position;
        dropPos.x +=5;

        this.DropItemIndex(0,dropPos, transform.parent.rotation);
    }

    protected virtual void DropItemIndex(int itemIndex, Vector3 dropPos, Quaternion dropRot){
        if(itemIndex >= this.inventory.Items.Count) return;
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        
        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, dropRot);
        this.inventory.Items.Remove(itemInventory);
    }
}
