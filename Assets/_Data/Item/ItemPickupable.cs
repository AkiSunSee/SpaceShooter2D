using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class ItemPickupable : AkiBehaviour
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
        this.sphereCollider.radius = 0.07f;
        Debug.LogWarning(transform.name + "LoadSphereCollider",gameObject);
    }

    public static ItemCode StringToItemCode(string itemName){
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }
    
    public virtual ItemCode GetItemCode(){
        return ItemPickupable.StringToItemCode(transform.parent.name);
    }

    public virtual void Picked(){
        ItemDropSpawner.Instance.Despawn(transform.parent);
    }
}
