using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : AkiBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected Inventory inventory;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
        this.LoadInventory();
    }

    protected virtual void LoadSphereCollider(){
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.35f;
        Debug.LogWarning(transform.name + "LoadSphereCollider",gameObject);
    }

    protected virtual void LoadRigidbody(){
        if(this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        this._rigidbody.isKinematic = true;
         Debug.LogWarning(transform.name + "LoadRigidbody",gameObject);
    }

    protected virtual void LoadInventory(){
        if(this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
         Debug.LogWarning(transform.name + "LoadInventory",gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other) {
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;
        
        ItemCode itemCode = itemPickupable.GetItemCode();
        if(this.inventory.AddItem(itemCode,1)){
            itemPickupable.Picked();
        }
    }
}
