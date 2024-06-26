using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMissle : BaseAbility
{
    [SerializeField] protected int damageMultiply = 5;
    [SerializeField] protected float explosionRadius = 8f;
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
        bulletCtrl.DmgSender.SetDamage((int)shooterCtrl.AttributesCtrl.GetAttributeByCode(AttributesCode.Attack).baseValue*this.damageMultiply);
        bulletCtrl.BulletImpact.SetSphereRadius(this.explosionRadius);
        bulletCtrl.gameObject.SetActive(true);

        MissleFly missleFly = bulletCtrl.GetComponentInChildren<MissleFly>();
        if(missleFly == null) Debug.LogError("You miss MissleFly script for Missle GameObject");
        missleFly.SetMoveSpeed(shooterCtrl.AttributesCtrl.GetAttributeByCode(AttributesCode.Speed).baseValue + 3.5f);
    }
}
