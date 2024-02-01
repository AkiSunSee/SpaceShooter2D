using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : AkiBehaviour
{
    [SerializeField] private DamageSender dmgSender;
    public DamageSender DmgSender {get => dmgSender;}

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn {get => despawn;}

    [SerializeField] protected Transform shooter;
    public Transform Shooter {get => shooter;}

    [SerializeField] protected BulletImpact bulletImpact;
    public BulletImpact BulletImpact => bulletImpact;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadDespawn();
        this.LoadBulletImpact();
    }

    protected virtual void LoadDamageSender(){
        if(this.dmgSender != null) return;
        this.dmgSender = GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender",gameObject);
    }

    protected virtual void LoadDespawn(){
        if(this.despawn != null) return;
        this.despawn = GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + ": LoadDespawn",gameObject);
    }

    protected virtual void LoadBulletImpact(){
        if(this.bulletImpact != null) return;
        this.bulletImpact = GetComponentInChildren<BulletImpact>();
        Debug.Log(transform.name + ": LoadBulletImpact",gameObject);
    }

    public virtual void SetShooter(Transform shooter){
        this.shooter = shooter;
    }
}
