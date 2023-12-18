using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class ItemPickupable : ItemAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider(){
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.2f;
        Debug.LogWarning(transform.name + "LoadSphereCollider",gameObject);
    }

    public static ItemCode StringToItemCode(string itemName){
       return ItemCodeParser.FromString(itemName);
    }
    
    public virtual ItemCode GetItemCode(){
        return ItemPickupable.StringToItemCode(transform.parent.name);
    }

    public virtual void Picked(){
        this.itemCtrl.ItemDespawn.DespawnObj();
    }

    public virtual void OnMouseDown(){
        PlayerCtrl.Instance.PlayerPickup.ItemPickup(this);
    }
}
