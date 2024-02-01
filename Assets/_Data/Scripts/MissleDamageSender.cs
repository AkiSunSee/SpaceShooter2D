using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleDamageSender : DamageSender
{
    public override void Send(Transform obj){
        DamageReceiver dmgReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (dmgReceiver == null) return;
        this.Send(dmgReceiver);
    }
}
