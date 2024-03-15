using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class ItemPickupable : ItemAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected Material outlineMaterial;
    protected Material baseMaterial;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadSpriteRenderer();
        this.LoadMaterial();
    }

    protected virtual void LoadMaterial(){
        if(this.outlineMaterial!= null) return;
        this.outlineMaterial = Resources.Load<Material>("Material/OutlineMat");
        Debug.LogWarning(transform.name+": LoadMaterial",gameObject);
    }

    protected virtual void LoadSphereCollider(){
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.2f;
        Debug.LogWarning(transform.name + "LoadSphereCollider",gameObject);
    }

    protected virtual void LoadSpriteRenderer(){
        if(this.spriteRenderer != null){
            this.baseMaterial = this.spriteRenderer.sharedMaterial;
            return;
        }
        this.spriteRenderer = transform.parent.Find("model").GetComponent<SpriteRenderer>();
        this.baseMaterial = this.spriteRenderer.sharedMaterial;
        Debug.LogWarning(transform.name + "LoadSpriteRenderer",gameObject);
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
        this.spriteRenderer.material = this.baseMaterial;
        PlayerCtrl.Instance.PlayerPickup.ItemPickup(this);
    }

    public virtual void OnMouseOver(){
       this.spriteRenderer.material = this.outlineMaterial;
    }

    public virtual void OnMouseExit(){
        this.spriteRenderer.material = this.baseMaterial;
    }
}
