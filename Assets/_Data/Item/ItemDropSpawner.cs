using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : DropRateSpawner
{
    private static ItemDropSpawner _instance;
    public static ItemDropSpawner Instance => _instance;

    protected override void Awake() {
        base.Awake();
        if(ItemDropSpawner._instance != null) Debug.LogError("Only 1 ItemDropSpawner allow to exist");
        ItemDropSpawner._instance = this;
    }

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList, Vector3 pos, Quaternion rot){
        List<ItemDropRate> dropItems = new List<ItemDropRate>();
        if(dropList.Count <1) return dropItems;

        dropItems = this.DropItems(dropList);
        foreach (ItemDropRate item in dropItems)
        {
            ItemCode itemCode = item.itemPSO.itemCode;
            Transform itemDrop = this.Spawn(itemCode.ToString(), this.RandomNearDropPos(pos), rot);
            if(itemDrop == null) continue;
            itemDrop.gameObject.SetActive(true);
        }

        return dropItems;
    }

    public virtual List<ItemDropRate> DropItems(List<ItemDropRate> items){
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();
        float rate, itemRate;
        int itemDropMore;
        foreach (ItemDropRate item in items)
        {
            rate = Random.Range(0,1f) * 100;
            itemRate = item.dropRate/1000 * GameDropRate();  // if item.dropRate = 1000 equal 1%
            itemDropMore = Mathf.FloorToInt(itemRate);
            if(itemDropMore >= 100){ 
                do{
                    itemRate -= 100;
                    droppedItems.Add(item);
                }while(itemRate>=100);
            }
            // Debug.Log("==================================");
            // Debug.Log("rate: "+rate);
            // Debug.Log("item.dropRate: "+item.dropRate);
            // Debug.Log("gameDroprate: "+GameDropRate());
            // Debug.Log("itemRate: "+itemRate);
            // Debug.Log("itemDropMore: "+itemDropMore);
            if(rate <= itemRate){
                droppedItems.Add(item);
            }
        }
        return droppedItems;
    }

    public virtual Transform DropFromInventory(ItemInventory itemInventory, Vector3 pos, Quaternion rot){
        ItemCode itemCode = itemInventory.itemProfile.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if(itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);   
        ItemCtrl itemCtrl = itemDrop.GetComponent<ItemCtrl>();
        itemCtrl.SetItemInventory(itemInventory);
        return itemDrop;
    }
}
