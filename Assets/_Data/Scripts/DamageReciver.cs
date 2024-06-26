using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver : AkiBehaviour
{
    [Header("Damage Reciver")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp = 1;
    public int HP => hp;
    [SerializeField] protected int hpMax  = 10;
    public int HpMax => hpMax;
    [SerializeField] protected bool isDead = false;

    protected override void OnEnable() {
        this.Reborn();
    }

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider(){
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.19f;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }
    public virtual void Reborn(){
        this.hp = this.hpMax;
        this.isDead = false;
    }

    public virtual void Add(int add){
        if(this.isDead) return;

        this.hp += add;
        if(this.hp > this.hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(int deduct){
        if(this.isDead) return;

        this.hp -= deduct;
        Transform fx = FXSpawner.Instance.Spawn(FXSpawner.TextDamage, this.transform.position, Quaternion.identity);
        fx.GetComponent<TextDamage>().SetDamage(deduct);
        fx.gameObject.SetActive(true);
        if(this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    public virtual bool IsDead(){
        return this.hp <= 0;
    }

    public virtual void SetCurrentHP(int hp){
        this.hp = hp;
    }

    public virtual int GetCurrentHP(){
        return this.hp;
    }

    protected virtual void CheckIsDead(){
        if(!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();
}
