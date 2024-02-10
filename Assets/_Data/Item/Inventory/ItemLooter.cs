using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : InventoryAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
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

    protected virtual void OnTriggerEnter(Collider other) {
        if (!other.TryGetComponent<ItemPickupable>(out var itemPickupable)) return;
        
        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        if(this.inventory.AddItem(itemInventory)){
            itemPickupable.Picked();
        }
    }
}
