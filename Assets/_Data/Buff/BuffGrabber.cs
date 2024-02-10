using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BuffGrabber : ShootableObjectAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    [SerializeField] protected List<BuffHandler> buffHandlers;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
        this.LoadBuffHandlers();
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

    protected virtual void LoadBuffHandlers(){
        if(this.buffHandlers.Count >0 ) return;
        BuffHandler[] arrays = GetComponentsInChildren<BuffHandler>();
        this.buffHandlers.AddRange(arrays);
        Debug.LogWarning(transform.name +": LoadBuffHandlers",gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other){
        if (!other.TryGetComponent<BuffPickupable>(out var buffPickupable)) return;
        BuffCtrl buffCtrl = buffPickupable.BuffCtrl;
        buffPickupable.Picked();
        foreach(BuffHandler buffHandler in this.buffHandlers){
            if(buffHandler.GetBuffCode() == buffCtrl.BuffProfileSO.buffCode){
                buffHandler.SetDuration(buffCtrl.BuffProfileSO.buffDuration);
                buffHandler.StartBuff(buffCtrl.BuffProfileSO.buffMultiplierValue);
            }
        }
    }
}
