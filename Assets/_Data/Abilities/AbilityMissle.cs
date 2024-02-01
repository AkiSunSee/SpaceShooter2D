using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMissle : BaseAbility
{
    [SerializeField] protected int damageMultiply = 5;
    [SerializeField] protected float explosionRadius = 35f;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.delay = 5f;
        this.timer = this.delay;
    }

    public override void Active(){
        if(!this.isReady) return;
        base.Active();
        this.ShootMissle();
    }

    protected virtual void ShootMissle(){
        AbilityObjectCtrl shooterCtrl = this.abilities.AbilityObjectCtrl;
        Vector3 spawnPos =  shooterCtrl.transform.position;
        Quaternion spawnRot = shooterCtrl.transform.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.Missle, spawnPos, spawnRot);
        this.SetMissleData(newBullet, shooterCtrl);
    }

    protected virtual void SetMissleData(Transform newBullet, AbilityObjectCtrl shooterCtrl){
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(this.transform.parent.parent);
        bulletCtrl.DmgSender.SetDamage(shooterCtrl.ShootableObjectSO.attack*this.damageMultiply);
        bulletCtrl.BulletImpact.SetSphereRadius(this.explosionRadius);
        bulletCtrl.gameObject.SetActive(true);
    }
}
