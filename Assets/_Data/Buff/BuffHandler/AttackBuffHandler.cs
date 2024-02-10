using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuffHandler : BuffHandler
{
    public override BuffCode GetBuffCode(){
        return BuffCode.AttackBuff;
    }
    
    protected override void Buff(float buffMultiplierValue){
        //this.buffGrabber.ShootableObjectCtrl.ObjMovement.SetSpeed(baseValue*buffMultiplierValue);
        int newValue = Mathf.CeilToInt(baseValue*buffMultiplierValue);
        this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetDamage(newValue);
    }

    protected override void BuffEnd(){
        //this.buffGrabber.ShootableObjectCtrl.ObjMovement.SetSpeed(baseValue);
        this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetDamage((int)baseValue);
    }

    protected override void GetBaseValue(){
        ShootableObjectCtrl sOC = this.buffGrabber.ShootableObjectCtrl.GetComponent<ShootableObjectCtrl>();
        this.baseValue = sOC.ShootableObjectSO.attack;
    }
}
