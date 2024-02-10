using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class BuffPickupable : BuffAbstract
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

    public static BuffCode StringToBuffCode(string buffName){
       return BuffCodeParser.FromString(buffName);
    }
    
    public virtual BuffCode GetBuffCode(){
        return BuffPickupable.StringToBuffCode(transform.parent.name);
    }

    public virtual void Picked(){
        this.buffCtrl.BuffDespawn.DespawnObj();
    }

}
