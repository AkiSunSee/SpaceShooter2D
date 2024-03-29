using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : AkiBehaviour
{
    [SerializeField] private Transform model;
    public Transform Model => model;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;

    [SerializeField] protected ShootableObjectSO shootableObjectSO;
    public ShootableObjectSO ShootableObjectSO => shootableObjectSO;

    [SerializeField] protected ObjShooting objShooting;
    public ObjShooting ObjShooting => objShooting;

    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;

    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected ObjMovement objMovement;
    public ObjMovement ObjMovement => objMovement;

    [SerializeField] protected AttributesCtrl attributesCtrl;
    public AttributesCtrl AttributesCtrl => attributesCtrl;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadShootableObjectSO();
        this.LoadObjShooting();
        this.LoadSpawner();
        this.LoadDamageReceiver();
        this.LoadObjMovement();
        this.LoadAttributesCtrl();
    }

    protected virtual void LoadObjMovement(){
        if(this.objMovement != null) return;
        this.objMovement = transform.GetComponentInChildren<ObjMovement>();
        Debug.LogWarning(transform.name+": LoadObjMovement",gameObject);
    }

    protected virtual void LoadDamageReceiver(){
        if(this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name+": LoadDamageReceiver",gameObject);
    }

    protected virtual void LoadSpawner(){
        if(this.spawner != null) return;
        this.spawner = transform.parent?.parent?.GetComponent<Spawner>();
        Debug.LogWarning(transform.name+": LoadSpawner",gameObject);
    }

    protected virtual void LoadModel(){
        if(this.model != null) return;
        this.model = transform.Find("model");
        Debug.LogWarning(transform.name+": LoadModel",gameObject);
    }

    protected virtual void LoadDespawn(){
        if(this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<Despawn>();
        Debug.LogWarning(transform.name+": LoadDespawn",gameObject);
    }

    protected virtual void LoadShootableObjectSO(){
        if(this.shootableObjectSO != null) return;
        string resPath = "ShootableObject/"+this.GetObjectTypeString()+"/"+ transform.name;
        this.shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name+ " "+ resPath +": LoadShootableObjectSO",gameObject);
    }

    protected virtual void LoadObjShooting(){
        if(this.objShooting != null) return;
        this.objShooting = transform.GetComponentInChildren<ObjShooting>();
        Debug.LogWarning(transform.name+": LoadObjShooting",gameObject);
    }

    protected virtual void LoadAttributesCtrl(){
        if(this.attributesCtrl != null) return;
        this.attributesCtrl = transform.GetComponentInChildren<AttributesCtrl>();
        Debug.LogWarning(transform.name+": LoadAttributesCtrl",gameObject);
    }

    protected abstract string GetObjectTypeString();
}
