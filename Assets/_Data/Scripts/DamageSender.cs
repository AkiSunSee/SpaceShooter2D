using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : AkiBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj){
        DamageReciver dmgReciver;
        dmgReciver  = obj.GetComponentInChildren<DamageReciver>();
        if (dmgReciver == null) return;
        this.Send(dmgReciver);
    }

    public virtual void Send(DamageReciver dmgReciver){
        dmgReciver.Deduct(this.damage);
    }
    
}
