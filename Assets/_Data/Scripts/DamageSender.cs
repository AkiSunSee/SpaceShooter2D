using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : AkiBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj){
        DamageReceiver dmgReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (dmgReceiver == null) return;
        this.Send(dmgReceiver);
        this.createFXImpact();
    }

    public virtual void SetDamage(int newDamage){
        this.damage = newDamage;
    }

    public virtual void Send(DamageReceiver dmgReceiver){
        dmgReceiver.Deduct(this.damage);
    }

    protected virtual void createFXImpact(){
        string fxName = this.GetImpactFX();
        Vector3 hitPos =transform.position;
        Quaternion hitRot = transform.parent.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFX(){
        return FXSpawner.FX2;
    }
    
}
