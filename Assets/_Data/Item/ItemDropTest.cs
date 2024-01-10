using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropTest : AkiBehaviour
{
    public JunkCtrl junkCtrl;
    public List<ItemDropCount> dropCountItems = new List<ItemDropCount>();
    public int dropCount =0;

    protected override void Start()
    {
        base.Start();
        //InvokeRepeating(nameof(this.Droping),2,0.2f);
        Invoke("Droping",1f);
    }

    protected virtual void Droping(){
        this.dropCount++;
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        List<ItemDropRate> dropItems = ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObjectSO.dropList, dropPos, dropRot);
        ItemDropCount itemDrop;
        foreach (var item in dropItems)
        {
            itemDrop = this.dropCountItems.Find(i => i.name == item.itemPSO.itemName);
            if(itemDrop == null){
                itemDrop = new ItemDropCount();
                itemDrop.name = item.itemPSO.itemName;
                this.dropCountItems.Add(itemDrop);
            }

            itemDrop.count ++;
            itemDrop.rate = (float)Math.Round((float)itemDrop.count/this.dropCount,2) *100;
        }
    }
}

[Serializable]
public class ItemDropCount{
    public string name;
    public float rate;
    public int count;
}

