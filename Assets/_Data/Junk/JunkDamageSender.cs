using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class JunkDamageSender : DamageSender
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadJunkCtrl();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadJunkCtrl(){
        if(this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected virtual void LoadSphereCollider(){
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = this.junkCtrl.ShootableObjectSO.radius;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected virtual void LoadRigidbody(){
        if(this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other){
        DamageReceiver damageReceiver = other.transform.GetComponent<DamageReceiver>();
        if(damageReceiver == null) return;
        if (other.transform.parent != PlayerCtrl.Instance.CurrentShip.transform) return;
        this.Send(damageReceiver);
    }
}
