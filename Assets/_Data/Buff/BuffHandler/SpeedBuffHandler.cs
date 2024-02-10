using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuffHandler : BuffHandler
{
    public override BuffCode GetBuffCode(){
        return BuffCode.SpeedBuff;
    }

    protected override void Buff(float buffMultiplierValue){
        //Debug.Log(baseValue*buffMultiplierValue);
        this.buffGrabber.ShootableObjectCtrl.ObjMovement.SetSpeed(baseValue*buffMultiplierValue);
    }

    protected override void BuffEnd(){
        this.buffGrabber.ShootableObjectCtrl.ObjMovement.SetSpeed(baseValue);
    }

    protected override void GetBaseValue(){
        ShootableObjectCtrl sOC = this.buffGrabber.ShootableObjectCtrl.GetComponent<ShootableObjectCtrl>();
        this.baseValue = sOC.ShootableObjectSO.speed;
    }
}
