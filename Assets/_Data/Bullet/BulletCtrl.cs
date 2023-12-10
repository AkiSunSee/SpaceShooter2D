using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : AkiBehaviour
{
    [SerializeField] private DamageSender dmgSender;
    public DamageSender DmgSender {get => dmgSender;}

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn {get => bulletDespawn;}

    [SerializeField] protected Transform shooter;
    public Transform Shooter {get => shooter;}

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadDamageSender(){
        if(this.dmgSender != null) return;
        this.dmgSender = GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender",gameObject);
    }

    protected virtual void LoadBulletDespawn(){
        if(this.bulletDespawn != null) return;
        this.bulletDespawn = GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn",gameObject);
    }

    public virtual void SetShooter(Transform shooter){
        this.shooter = shooter;
    }
}
