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

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadShootableObjectSO();
        this.LoadObjShooting();
        this.LoadSpawner();
        this.LoadDamageReceiver();
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

    protected abstract string GetObjectTypeString();
}
