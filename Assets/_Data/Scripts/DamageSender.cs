using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : AkiBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj){
        DamageReciver dmgReciver = obj.GetComponentInChildren<DamageReciver>();
        if (dmgReciver == null) return;
        this.Send(dmgReciver);
        this.createFXImpact();
    }

    public virtual void Send(DamageReciver dmgReciver){
        dmgReciver.Deduct(this.damage);
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
