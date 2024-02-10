using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedBuffHandler : BuffHandler
{
    public override BuffCode GetBuffCode(){
        return BuffCode.AttackSpeedBuff;
    }

    protected override void Buff(float buffMultiplierValue){
        this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetShootDelay(baseValue/buffMultiplierValue);
    }

    protected override void BuffEnd(){
        this.buffGrabber.ShootableObjectCtrl.ObjShooting.SetShootDelay(baseValue);
    }

    protected override void GetBaseValue(){
        ShootableObjectCtrl sOC = this.buffGrabber.ShootableObjectCtrl.GetComponent<ShootableObjectCtrl>();
        this.baseValue = sOC.ShootableObjectSO.shootingSpeed;
    }
}
