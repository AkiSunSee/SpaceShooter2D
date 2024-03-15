using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjShooting : AkiBehaviour
{
    [SerializeField] protected bool shooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 1f;

    [SerializeField] protected int damage;

    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtrl();
        this.LoadData();
    }

    protected virtual void LoadShootableObjectCtrl(){
        if(this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.LogWarning(transform.name+": LoadShootableObjectCtrl",gameObject);
    }

    private void Update() {
        this.IsShooting();
    }
    private void FixedUpdate() {
        this.Shooting();
    }

    protected abstract bool IsShooting();

    protected virtual void Shooting(){
        if(!this.CanShoot()) this.shootTimer += Time.fixedDeltaTime;
        if(this.shootTimer < shootDelay) return;
        if(!IsShooting()) return;
        //if(InputManager.Instance.IsRightMouseDown == 0) return;
        Vector3 spawnPos = transform.parent.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.Bullet1, spawnPos, rotation);
        if(newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        this.shootTimer = 0;
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
        bulletCtrl.DmgSender.SetDamage(this.damage);
    }

    protected virtual bool CanShoot(){
        return this.shootTimer >= this.shootDelay;
    }

    protected virtual void LoadData(){
        this.shootDelay = this.shootableObjectCtrl.AttributesCtrl.GetAttributeByCode(AttributesCode.AttackSpeed).currentValue;
        this.shootTimer = shootDelay;
        this.damage = (int)this.shootableObjectCtrl.AttributesCtrl.GetAttributeByCode(AttributesCode.Attack).currentValue;
    }

    public virtual void SetDamage(int newDamage){
        this.damage = newDamage;
    }

    public virtual void SetShootDelay(float newShootDelay){
        this.shootDelay = newShootDelay;
    }
}
